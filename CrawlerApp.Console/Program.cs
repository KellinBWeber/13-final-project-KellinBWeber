using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Data;
using System.Data.SqlClient;
using CrawlerApp.DataStore;

namespace CrawlerApp.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //the link to crawl and the empty list to store all the crawled links
            string _testlink = "https://www.ksl.com/";
            List<string> _testList = new List<string>();

            //create the crawler
            Crawler testCrawler = new Crawler(_testList, _testlink);

            //create crawler DB connection
            CrawlerAppDB _crawlerDatabase = new CrawlerAppDB(testCrawler._extractedURL);

            //input links from Crawler to Database
            if (_crawlerDatabase.TestDbConn() == 1)
            {
                _crawlerDatabase.Insert();
            }

            System.Console.ReadKey();

        }
    }
}
