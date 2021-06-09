using MySql.Data.MySqlClient;
using System;
using System.Data.Common;


namespace Projekcior.Models {
    public static class Database {
        static DbConnection connection;
 

        public static DbConnection GetConnection() {
            try {
                if (connection == null) {
                    connection = new MySqlConnection("server=remotemysql.com;port=3306;user=3MJdM8nmSo;password=k86zfOZW2n;database=3MJdM8nmSo");
                    connection.Open();
                }
                if (connection.State != System.Data.ConnectionState.Open) {
                    throw new Exception("Database Conenction Broken");
                }
            }
            catch (Exception) {
                GetConnection();
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