using System;
using System.Collections.Generic;

namespace LogBoard.Models
{
    public class GraphChartModel
    {
        public string id { get; set; }
        public List<Data> data { get; set; }

    }

    public class Data
    {
        public string x { get; set; }
        public int y { get; set; }
    }
}

