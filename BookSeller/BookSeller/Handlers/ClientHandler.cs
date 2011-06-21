using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BookSeller
{
    class ClientHandler
    {
        private ClientInfo[] Clients = new ClientInfo[100];
        private string qry;
        private string MyConString = "SERVER=127.0.0.1;" + "DATABASE=Bookseller;" +
                                        "UID=root;" + "PASSWORD=mangos;";

        public ClientHandler(out ClientInfo[] clientInfo)
        {
            ListWithOutFilter();
            clientInfo = Clients;
        }

        public ClientHandler(out ClientInfo[] clientInfo, string Column, string Value)
        {
            ListWithFilter(Column, Value);
            clientInfo = Clients;
        }

        public ClientHandler(ClientInfo client, frmViewClients.SaveOrUpdateOrDelete saveOrUpdateDelete, out bool success)
        {
            if (saveOrUpdateDelete == frmViewClients.SaveOrUpdateOrDelete.Save)
            {
                qry = "INSERT INTO clients (FirstName,LastName,Street,City,Province,Zip,E_Mail,Books_purchased,Books_hired) " +
                    "VALUES (@FirstName,@LastName,@Street,@City,@Province,@Zip,@E_Mail,@Books_purchased,@Books_hired)";
            }
            else if (saveOrUpdateDelete == frmViewClients.SaveOrUpdateOrDelete.Update)
            {
                qry = "UPDATE clients SET FirstName = @FirstName,LastName = @LastName,Street = @Street,City = @City,Province = @Province," +
                "Zip = @Zip,E_Mail = @E_Mail,Books_purchased = @Books_purchased,Books_hired = Books_hired WHERE FirstName = @FirstName";
            }
            else
            {
                qry = "DELETE FROM clients WHERE FirstName = @FirstName";
            }

            using (MySqlConnection Connection = new MySqlConnection(MyConString))
            {
                success = false;

                try
                {
                    MySqlCommand cmd = new MySqlCommand(qry, Connection);
                    cmd.Parameters.Add(new MySqlParameter("@FirstName", (object)client.FirstName));
                    cmd.Parameters.Add(new MySqlParameter("@LastName", (object)client.LastName));
                    cmd.Parameters.Add(new MySqlParameter("@Street", (object)client.Street));
                    cmd.Parameters.Add(new MySqlParameter("@City", (object)client.City));
                    cmd.Parameters.Add(new MySqlParameter("@Province", (object)client.Province));
                    cmd.Parameters.Add(new MySqlParameter("@Zip", (object)client.Zip));
                    cmd.Parameters.Add(new MySqlParameter("@E_Mail", (object)client.E_Mail));
                    cmd.Parameters.Add(new MySqlParameter("@Books_purchased", (object)client.Books_purchased));
                    cmd.Parameters.Add(new MySqlParameter("@Books_hired", (object)client.Books_hired));

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

        private void ListWithFilter(string Column, string Value)
        {
            qry = "SELECT * FROM clients WHERE " + Column + " like '%" + Value + "%'";
            List();
        }

        private void ListWithOutFilter()
        {
            qry = "SELECT * FROM clients ORDER BY FirstName";
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
                            ClientInfo Client = new ClientInfo
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Street = reader["Street"].ToString(),
                                City = reader["City"].ToString(),
                                Province = reader["Province"].ToString(),
                                Zip = reader["Zip"].ToString(),
                                E_Mail = reader["E_Mail"].ToString(),
                                Books_purchased = int.Parse(reader["Books_purchased"].ToString()),
                                Books_hired = int.Parse(reader["Books_hired"].ToString()),
                            };

                            Clients[Count] = Client;
                            Count++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Clients where found", "Clients", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
