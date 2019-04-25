using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace CrawlerApp.DataStore
{
    public class CrawlerAppDB
    {
        //List to store links
        private List<string> _linksForDB;

        //setting up the data for the insert.
        public CrawlerAppDB(List<string> inputList)
        {
            _linksForDB = inputList;
        }

        //establishing database connection
        public bool TestDbConn()
        {
            string connectionString = null;
            SqlConnection cnn;

            connectionString = "Server= (LocalDB)\\MSSQLLocalDB; Database= CS4790Crawler;Integrated Security = SSPI;";
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                System.Console.WriteLine("Connection Successful.");
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                return false;
            }
        }

        public void Insert()
        {
            string connectionString = null;
            string sql = null;
            SqlCommand command;
            SqlConnection cnn;
            connectionString = "Server= (LocalDB)\\MSSQLLocalDB; Database= CS4790Crawler;Integrated Security = SSPI; ";
            
            using (cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                
                sql = "INSERT INTO Links (Link) VALUES (@Link)";

                command = new SqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@Link", DbType.String);

                foreach(var e in _linksForDB)
                {
                    command.Parameters[0].Value = e;
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        System.Console.WriteLine("Error on insert.");
                        cnn.Close();
                    }
                    else
                    {
                        //TODO
                    }
                }

                System.Console.WriteLine("Data inserted into Database.");
                cnn.Close();
            }
        }
        public void printLinks()
        {
            foreach (string e in _linksForDB)
            {
                System.Console.WriteLine(e);
            }
        }

    }    
}
