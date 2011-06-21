using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BookSeller
{
    class LogInHandler
    {
        string qry = "SELECT Password FROM SalesPersons WHERE User=@username";
        string MyConString = "SERVER=127.0.0.1;" + "DATABASE=Bookseller;" +
                        "UID=root;" + "PASSWORD=mangos;";

        public LogInHandler(out bool Success,string user, string password)
        {
            using (MySqlConnection Connection = new MySqlConnection(MyConString))
            {
                Success = false;

                try
                {
                    Connection.Open();
                    MySqlCommand cmd = new MySqlCommand(qry, Connection);
                    cmd.Parameters.Add(new MySqlParameter("username", user));
                    MySqlDataReader reader;
                    reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (password == reader["Password"].ToString())
                            {
                                Success = true;
                            }
                            else
                            {
                                MessageBox.Show("Password Incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Success = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username was not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Success = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Success = false;
                }
                finally
                {
                    Connection.Close();
                }
            }
        }
    }
}
