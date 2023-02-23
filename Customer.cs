using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace VR.Models
{
    public class Customer
    {
        public int no { get;set; }
        public int Cid { get; set; }
        [Required]
        public string name { get; set; }
        public int IsSubcribedToNewsletter { get; set; }
        public string MembershipType { get; set; }
        public int Mid { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}