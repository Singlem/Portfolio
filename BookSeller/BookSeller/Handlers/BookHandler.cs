using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BookSeller
{
    class BookHandler
    {
        private Books[] Test = new Books[100];
        private string qry;
        private string MyConString = "SERVER=127.0.0.1;" + "DATABASE=Bookseller;" +
                                        "UID=root;" + "PASSWORD=mangos;";

        public BookHandler(out Books[] books)
        {
            ListWithOutFilter();
            books = Test;
        }

        public BookHandler(out Books[] books, string Column, string Value)
        {
            ListWithFilter(Column, Value);
            books = Test;
        }

        public BookHandler(Books BookInfo, frmBookViewer.SaveOrUpdateDelete saveOrUpdateDelete, string old_ISBN, out bool success)
        {
            if (saveOrUpdateDelete == frmBookViewer.SaveOrUpdateDelete.Save)
            {
                qry = "INSERT INTO Books (Title,Author,ISBN,Year,Pages,Price,In_Stock,Hired_Out,pic)" +
                      "VALUES (@Title,@Author,@ISBN,@Year,@Pages,@Price,@In_Stock,@Hired_Out,@pic)";
            }
            else if (saveOrUpdateDelete == frmBookViewer.SaveOrUpdateDelete.Update)
            {
                qry = "UPDATE Books SET Title = @Title,Author = @Author,ISBN = @ISBN,Year = @Year," +
                      "Pages = @Pages,Price = @Price,In_Stock = @In_Stock,Hired_Out = @Hired_Out, pic = @pic WHERE ISBN = @OLD_ISBN";
            }
            else
            {
                qry = "DELETE FROM Books WHERE ISBN = @ISBN";
            }

            using (MySqlConnection Connection = new MySqlConnection(MyConString))
            {
                success = false;

                try
                {
                    MySqlCommand cmd = new MySqlCommand(qry, Connection);
                    cmd.Parameters.Add(new MySqlParameter("@Title", (object)BookInfo.Title));
                    cmd.Parameters.Add(new MySqlParameter("@Author", (object)BookInfo.Author));
                    cmd.Parameters.Add(new MySqlParameter("@ISBN", (object)BookInfo.ISBN));
                    cmd.Parameters.Add(new MySqlParameter("@Year", (object)BookInfo.Year));
                    cmd.Parameters.Add(new MySqlParameter("@Pages", (object)BookInfo.Pages));
                    cmd.Parameters.Add(new MySqlParameter("@Price", (object)BookInfo.Price));
                    cmd.Parameters.Add(new MySqlParameter("@In_Stock", (object)BookInfo.In_Stock));
                    cmd.Parameters.Add(new MySqlParameter("@Hired_Out", (object)BookInfo.Hired_Out));
                    cmd.Parameters.Add(new MySqlParameter("@pic", (object)BookInfo.pic));
                    cmd.Parameters.Add(new MySqlParameter("@OLD_ISBN", (object)old_ISBN));

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        private void ListWithOutFilter()
        {
            qry = "SELECT * FROM Books ORDER BY Title";
            List();
        }

        private void ListWithFilter(string Column, string Value)
        {
            qry = "SELECT * FROM Books WHERE " + Column + " like '%" + Value + "%'";
            List();
        }

        private void List()
        {
            using (MySqlConnection Connection = new MySqlConnection(MyConString))
            {
                try
                {
                    Connection.Open();
                    MySqlCommand cmd = new MySqlCommand(qry, Connection);
                    MySqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    int Count = 0;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Books BookInfo = new Books
                            {
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                ISBN = reader["ISBN"].ToString(),
                                Year = reader["Year"].ToString(),
                                Pages = int.Parse(reader["Pages"].ToString()),
                                Price = decimal.Parse(reader["Price"].ToString()),
                                In_Stock = int.Parse(reader["In_Stock"].ToString()),
                                Hired_Out = int.Parse(reader["Hired_Out"].ToString()),
                                pic = (byte[])reader["pic"],
                            };

                           Test[Count] = BookInfo;
                           Count++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Books where found", "Books", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }
    }
}
