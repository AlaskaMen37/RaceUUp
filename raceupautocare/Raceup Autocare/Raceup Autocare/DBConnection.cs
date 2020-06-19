﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Raceup_Autocare
{
    class DBConnection
    {
     
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\database\raceup_db_new2.accdb";
        public static OleDbConnection thisConnection = null;

        public OleDbDataReader ConnectToOleDB(String sqlQuery) {
            thisConnection = new OleDbConnection(connectionString);
            
            thisConnection.Open();

            OleDbCommand userCommand = new OleDbCommand(sqlQuery, thisConnection);
            OleDbDataReader userReader = userCommand.ExecuteReader();
            
            return userReader;
        }

        public void CloseConnection() {
            thisConnection.Close();
        }
    }
}
