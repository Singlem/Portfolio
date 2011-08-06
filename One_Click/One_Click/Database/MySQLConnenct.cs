using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using One_Click.Properties;

namespace One_Click
{
    /// <summary>
    /// 3 types of databases used by mangos
    /// </summary>
    public enum Database
    {
        Mangos,
        Realm,
        Characters
    };

    public static class MySQLConnenct
    {
        private static MySqlConnection _conn;
        private static MySqlCommand _command;

        /// <summary>
        /// generate a password in SHA1
        /// </summary>
        public static string PasswordQuery(string Query, Database _database)
        {
            string Result;

            if (!IsConnected)
                return null;

            try
            {
                using (_conn = new MySqlConnection(ConnectionString(_database)))
                {
                    _command = new MySqlCommand(Query, _conn);
                    _conn.Open();

                    using (var reader = _command.ExecuteReader())
                    {
                        reader.Read();
                        byte[] temp = (byte[])reader[0];
                        Result = System.Text.Encoding.UTF8.GetString(temp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There where a Error\n" + ex);
                Result = null;
            }

            return Result;
        }

        /// <summary>
        /// Insert a query into database
        /// </summary>
        public static void Insert(string query, Database _database)
        {
            if (!IsConnected)
            {
                System.Windows.Forms.MessageBox.Show("No connection to database, please check settings", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _conn = new MySqlConnection(ConnectionString(_database));
                _command = new MySqlCommand(query, _conn);
                _conn.Open();
                _command.ExecuteNonQuery();
                _command.Connection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Data not recorded " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _conn.Close();
            }
        }

        /// <summary>
        /// Queries the database and return a int value
        /// </summary>
        public static int StatusQuery(string Query, Database _database)
        {
            int Value;
            if (!IsConnected)
                return 0;

            using (_conn = new MySqlConnection(ConnectionString(_database)))
            {
                _command = new MySqlCommand(Query, _conn);
                _conn.Open();

                using (var reader = _command.ExecuteReader())
                {
                    reader.Read();
                    Value = reader[0].ToInt32();
                }
            }

            return Value;
        }

        #region Properties
        /// <summary>
        /// generate a connectionstring from the config
        /// </summary>
        private static String ConnectionString(Database _database)
        {
            string DB = "";
            switch (_database)
            {
                case Database.Characters:
                    DB = Settings.Default.DB_Char;
                    break;
                case Database.Realm:
                    DB = Settings.Default.DB_Realm;
                    break;
                case Database.Mangos:
                    DB = Settings.Default.DB_Mangos;
                    break;
            }
         
            return String.Format("Server={0};Port={1};Uid={2};Pwd={3};Database={4};character set=utf8;Connection Timeout=10",
                    Settings.Default.Host,
                    Settings.Default.Port,
                    Settings.Default.User,
                    Settings.Default.Pass,
                    DB);
        }

        /// <summary>
        /// Check if connected to Database
        /// </summary>
        public static bool IsConnected
        {
            get
            {
                try
                {
                    _conn = new MySqlConnection(ConnectionString(Database.Mangos));
                    _conn.Open();
                    _conn.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        #endregion
    }
}