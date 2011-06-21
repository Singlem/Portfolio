using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace BookSeller
{
    class SaleAndHireHandler
    {
        private int in_stock;
        private int books_purchased;
        private int books_hired;
        private int hired_out;
        private string ISBN;
        private string firstname;
        private string lastname;
        private string qry;
        private string MyConString = "SERVER=127.0.0.1;" + "DATABASE=Bookseller;" +
                                                "UID=root;" + "PASSWORD=mangos;";

        public SaleAndHireHandler(string isbn , string clientFirstName, string clientLastName, frmSaleAndHire.SaleOrHire saleOrHire)
        {
            ISBN = isbn;
            firstname = clientFirstName;
            lastname = clientLastName;
            if (saleOrHire == frmSaleAndHire.SaleOrHire.Sale)
            {
                GetValues();
                Sale();
            }
            else if (saleOrHire == frmSaleAndHire.SaleOrHire.Hire)
            {
                GetValues();
                Hire();
            }
            else if (saleOrHire == frmSaleAndHire.SaleOrHire.Hold_Hire)
            {
                GetValues();
                Hold_Hire();
            }
        }

        public SaleAndHireHandler(string name, string isbn)
        {
            Order(name, isbn);
        }

        private void Hold_Hire()
        {
            using (MySqlConnection Connection = new MySqlConnection(MyConString))
            {
                try
                {
                    in_stock--;
                    qry = "UPDATE Books SET In_Stock = @In_Stock WHERE ISBN = @ISBN;";
                    qry = qry + "UPDATE Clients SET Hold_Hire = true WHERE FirstName = @FirstName AND LastName = @LastName;";
                    qry = qry + "INSERT INTO hold_Hire VALUES (@FirstName, @LastName, @ISBN);";
                    MySqlCommand cmd = new MySqlCommand(qry, Connection);
                    cmd.Parameters.Add(new MySqlParameter("@In_Stock", (object)in_stock));
                    cmd.Parameters.Add(new MySqlParameter("@ISBN", (object)ISBN));
                    cmd.Parameters.Add(new MySqlParameter("@FirstName", (object)firstname));
                    cmd.Parameters.Add(new MySqlParameter("@LastName", (object)lastname));

                    Connection.Open();
                    cmd.ExecuteNonQuery();
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

        private void GetValues()
        {
            qry = "SELECT In_Stock,Hired_Out FROM books WHERE ISBN = @ISBN";
            using (MySqlConnection Connection = new MySqlConnection(MyConString))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(qry, Connection);
                    cmd.Parameters.Add(new MySqlParameter("@ISBN",(object)ISBN));
                    MySqlDataReader reader;
                    Connection.Open();
                    reader = cmd.ExecuteReader();
                    in_stock = int.Parse(reader["In_Stock"].ToString());
                    hired_out = int.Parse(reader["Hired_Out"].ToString());
                    reader.Close();
                    cmd.Parameters.Clear();
                    qry = "SELECT Books_purchased,Books_hired FROM clients WHERE FirstName = @FirstName AND LastName = @LastName";
                    cmd.Parameters.Add(new MySqlParameter("@FirstName", (object)firstname));
                    cmd.Parameters.Add(new MySqlParameter("@LastName", (object)lastname));
                    reader = cmd.ExecuteReader();
                    books_purchased = int.Parse(reader["Books_purchased"].ToString());
                    books_hired = int.Parse(reader["Books_hired"].ToString());
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

        private void Order(string Name, String ISBN)
        {
            qry = "INSERT INTO On_Order VALUES (@Name,@ISBN)";
            using (MySqlConnection Connection = new MySqlConnection(MyConString))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(qry, Connection);
                    cmd.Parameters.Add(new MySqlParameter("@Name", (object)Name));
                    cmd.Parameters.Add(new MySqlParameter("@ISBN", (object)ISBN));

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book on order","Order",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        private void Hire()
        {
            using (MySqlConnection Connection = new MySqlConnection(MyConString))
            {
                try
                {
                    books_hired++;
                    in_stock--;
                    hired_out--;
                    qry = "UPDATE clients SET Books_hired = @Books_hired WHERE FirstName = @FirstName AND LastName = @LastName;";
                    qry =  qry + "UPDATE books SET In_Stock = @In_Stock, Hired_Out = @Hired_Out WHERE ISBN = @ISBN;";
                    MySqlCommand cmd = new MySqlCommand(qry, Connection);
                    cmd.Parameters.Add(new MySqlParameter("@Books_hired", (object)books_hired));
                    cmd.Parameters.Add(new MySqlParameter("@FirstName", (object)firstname));
                    cmd.Parameters.Add(new MySqlParameter("@LastName", (object)lastname));
                    cmd.Parameters.Add(new MySqlParameter("@In_Stock", (object)in_stock));
                    cmd.Parameters.Add(new MySqlParameter("@Hired_Out", (object)hired_out));

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Hired", "Hire", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Sale()
        {
            using (MySqlConnection Connection = new MySqlConnection(MyConString))
            {
                try
                {
                    in_stock--;
                    books_purchased++;
                    qry = "UPDATE clients SET Books_purchased = @Books_purchased WHERE FirstName = @FirstName AND LastName = @LastName;";
                    qry = qry + "UPDATE books SET In_Stock = @In_Stock WHERE ISBN = @ISBN;";
                    MySqlCommand cmd = new MySqlCommand(qry, Connection);
                    cmd.Parameters.Add(new MySqlParameter("@Books_purchased", (object)books_purchased));
                    cmd.Parameters.Add(new MySqlParameter("@In_Stock", (object)in_stock));

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sold book", "Hire", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
