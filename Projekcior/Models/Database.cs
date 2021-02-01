using MySql.Data.MySqlClient;
using System;
using System.Data.Common;


namespace Projekcior.Models {
    public static class Database {
        static DbConnection connection;
 

        public static DbConnection GetConnection() {
            if (connection == null) {
                connection = new MySqlConnection("server=localhost;port=3325;user=root;password=ZAQ!2wsx;database=Car-go_db");
                connection.Open();
            }
            if (connection.State != System.Data.ConnectionState.Open) {
                throw new Exception("Database Conenction Broken");
            }
            return connection;
        }

        public static void AddParameter(this DbCommand cmd, string name, object value) {
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            cmd.Parameters.Add(parameter);
        }
    }

}