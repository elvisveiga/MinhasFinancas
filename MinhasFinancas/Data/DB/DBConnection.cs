using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MinhasFinancas.Data.DB
{
    public class DBConnection : IDisposable
    {
        private SqlConnection connection;
        public void Dispose()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.AppSettings.Get("connection");
            connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}