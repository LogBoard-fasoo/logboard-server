using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogBoard.Controllers.Models
{
    public class VisitedUrl
    {
        [key]
        public int visitedUrl_id { get; set; }
        public string url { get; set; }
        public int stay { get; set; }
        public int read_ratio { get; set; }
        public string date_visited { get; set; }
        public string ip_address { get; set; }
        public int urlCategory_id { get; set; }
    }
}
