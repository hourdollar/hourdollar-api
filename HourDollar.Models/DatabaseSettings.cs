using System;
using MySqlConnector;

namespace HourDollar.Models
{
    public class DatabaseSettings : IDisposable
    {
        public MySqlConnection Connection { get; }

        public DatabaseSettings(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}