namespace UrlScan.Models
{
    public class Page
    {
        public string country { get; set; }
        public string server { get; set; }
        public string ip { get; set; }
        public string mimeType { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public int tlsValidDays { get; set; }
        public int tlsAgeDays { get; set; }
        public string ptr { get; set; }
        public DateTime tlsValidFrom { get; set; }
        public string domain { get; set; }
        public int umbrellaRank { get; set; }
        public string apexDomain { get; set; }
        public string asnname { get; set; }
        public string asn { get; set; }
        public string tlsIssuer { get; set; }
        public string status { get; set; }
    }

    public class Result
    {
        public Task task { get; set; }
        public Stats stats { get; set; }
        public Page page { get; set; }
        public string _id { get; set; }
        public object _score { get; set; }
        public List<object> sort { get; set; }
        public string result { get; set; }
        public string screenshot { get; set; }
    }

    public class Root
    {
        public List<Result> results { get; set; }
    }

    public class Stats
    {
        public int uniqIPs { get; set; }
        public int uniqCountries { get; set; }
        public int dataLength { get; set; }
        public int encodedDataLength { get; set; }
        public int requests { get; set; }
    }

    public class Task
    {
        public string visibility { get; set; }
        public string method { get; set; }
        public string domain { get; set; }
        public string apexDomain { get; set; }
        public DateTime time { get; set; }
        public string uuid { get; set; }
        public string url { get; set; }
    }
}