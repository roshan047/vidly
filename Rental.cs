using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VR.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int Cid { get; set; }
        //public string Mname { get; set; }
        public DateTime DateRented { get; set; }
        public int Mid { get; set; }
       
    }
}