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
        private List<string> _linksForDatabase; //for storing all the links for database

        //set up data for inserting
        public CrawlerAppDB(List<string> inputListForDatabase)
        {
            _linksForDatabase = inputListForDatabase;
        }

        //try to establish database connection
        public int TestDbConn()
        {
            string connectionString = null;
            SqlConnection cnn;

            connectionString = "Server= (LocalDB)\\MSSQLLocalDB; Database= CS2550Tutor;Integrated Security = SSPI;";
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                System.Console.WriteLine("Successfully Established Database Connection!");
                cnn.Close();
                return 1;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                return -1;
            }
        }

        public void Insert()
        {
            string connetionString = null;
            string sql = null;
            SqlCommand command;
            SqlConnection cnn;
            connetionString = "Server= (LocalDB)\\MSSQLLocalDB; Database= CS2550Tutor;Integrated Security = SSPI; ";
            
            using (cnn = new SqlConnection(connetionString))
            {
                cnn.Open();

                
                sql = "INSERT INTO MyLinks (Link) VALUES (@Link)";

                command = new SqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@Link", DbType.String);

                foreach(var e in _linksForDatabase)
                {
                    command.Parameters[0].Value = e;
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        System.Console.WriteLine("Error inserting data into Database!");
                        cnn.Close();
                    }
                    else
                    {
                        //use for testing success insert
                        //System.Console.WriteLine("SUCCESSFULLY insert data into Database!");
                    }
                }

                System.Console.WriteLine("SUCCESSFULLY insert data into Database!");
                cnn.Close();
            }
        }

        //testing purpose
        public void printLinks()
        {
            foreach (string e in _linksForDatabase)
            {
                System.Console.WriteLine(e);
            }
        }

    }    
}
