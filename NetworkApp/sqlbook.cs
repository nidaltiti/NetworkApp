using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace Network_App
{
    class sqlbook
    { public void save_data(int a ,int b)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var pathToDatabase = @"Resources/ip.db3";
            var connectionString = String.Format("Data Source={0};Version=3;", pathToDatabase);
            SqliteConnection _dbConnection =
new SqliteConnection(connectionString);
            _dbConnection.Open();

            string sql = "insert into ipTable (Name,ipAddress,Port) values ('Me', '0001','4367')";
            SqliteCommand command = new SqliteCommand(sql, _dbConnection);
            command.ExecuteNonQuery();
            _dbConnection.Close();
        }
    }
}
