using System;

namespace CrawlerApp.Client.Models
{
    public class ErrorViewModel
    {
        public string _RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(_RequestId);
    }
}