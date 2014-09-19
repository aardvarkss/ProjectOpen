using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOpen.Models
{
    public class HeadingLine
    {
        public string PageTitle { get; set; }
        public string PageSubtitle { get; set; }

        public string GraphATitle { get; set; }
        public List<int> GraphA { get; set; }

        public string GraphBTitle { get; set; }
        public List<int> GraphB { get; set; }

    }
}