using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VR.Models
{
    public class Movie
    {
        public int Mid { get; set; }
        public string Genre { get; set; }
        public DateTime Rel { get; set; }
        public DateTime upload { get; set; }
        public int instock { get; set; }
        public string name { get; set; }
    }
}