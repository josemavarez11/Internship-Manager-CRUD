using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace GestorPasantias
{
    internal class Connection
    {
        private static string connectionString = "Server=localhost; port=5432; user id=postgres; password=jose.29932288; database=gestion_pasantias;";
        static NpgsqlConnection connection;
        public Connection(){}

        public static NpgsqlConnection connect()
        {
            connection = new NpgsqlConnection(connectionString);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public static void disconnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}