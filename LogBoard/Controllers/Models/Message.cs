using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogBoard.Controllers.Models
{
    public class Message
    {
        [key]
        public int message_id { get; set; }
        public string message_type { get; set; }
        public string valid_date { get; set; }
        public string message { get; set; }
        public string url { get; set; }
        public string ip_address { get; set; }
    }
}
