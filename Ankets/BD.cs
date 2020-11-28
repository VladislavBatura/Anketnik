using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace Ankets
{
    class BD
    {
        static string myBD = "server=localhost;port=3306;username=root;password=root;database=applications";
        string path = @"connection.txt";
        static string connectionBD;
        MySqlConnection connection;

        public BD()
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    connectionBD = sr.ReadLine();
                }
            }
            catch (Exception e)
            {

            }
            connection = new MySqlConnection(connectionBD);
        }

        public void openBD()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeBD()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
