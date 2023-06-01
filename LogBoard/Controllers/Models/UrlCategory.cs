using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogBoard.Controllers.Models
{
    public class UrlCategory
    {
        [key]
        public int urlCategory_id { get; set; }
        public string urlCategory { get; set; }
    }
}
