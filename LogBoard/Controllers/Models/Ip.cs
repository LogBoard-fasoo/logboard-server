using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogBoard.Controllers.Models
{
    public class Ip
    {
        [key]
        public string ip_address { get; set; }
        public string company_name { get; set; }
    }
}
