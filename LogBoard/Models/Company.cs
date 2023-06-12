namespace LogBoard.Models
{
    public class Company
    {
        public int rank { get; set; }

        public int count { get; set; }

        public string name { get; set; }

        public string domain { get; set; }

        public string description { get; set; }

        public string revenueRange { get; set; }

        public string country { get; set; }

        public string foundedYear { get; set; }

        public string employeeRange { get; set; }

        public string industry { get; set; }

        public string[] categories { get; set; }

        public string[] technologies { get; set; }
    }
}
