﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Finisar.SQLite;

namespace WpfApp3
{
    class DbConnector
    {
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;

        public DbConnector()
        {
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
        }

        public void OpenConnection()
        {
            // open the connection:
            sqlite_conn.Open();
        }

        public void PrintDebugging()
        {
            this.OpenConnection();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // But how do we read something out of our table ?
            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT * FROM items";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                System.Console.WriteLine(sqlite_datareader["name"]);
            }

            this.DisposeConnection();
        }

        public void DisposeConnection()
        {
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
        }
    }
}
