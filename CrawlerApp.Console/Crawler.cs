using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using HtmlAgilityPack;
using MySql.Data.Entity;
using System.Data.SqlClient;
using CrawlerApp.DataStore;

//use Pomelo SQL

namespace CrawlerApp.Console
{
    public class Crawler
    {
        public List<string> _extractedURL;

        public Crawler(List<string> listToStoreURLs, string inputLink)
        {
            _extractedURL = listToStoreURLs;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(inputLink);
            // selectnode //a[@href]
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                var extractedUrl = node.GetAttributeValue("href", string.Empty);
                
                _extractedURL.Add(GetAbsoluteUrl(inputLink, extractedUrl));
            }
        }

        /*
         this method takes in the Base input url and also the url that the crawler crawls
         then makes sure to give out the full html link 
             */
        static string GetAbsoluteUrl(string baseUrl, string url)
        {
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            if (!uri.IsAbsoluteUri)
                uri = new Uri(new Uri(baseUrl), uri);
            return uri.ToString();
        }
        
        //testing purpose
        public void printAllLinks()
        {
            foreach(string e in _extractedURL)
            {
                System.Console.WriteLine(e);
            }
        }


    }
}
