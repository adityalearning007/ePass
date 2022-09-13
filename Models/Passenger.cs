using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ePass.Models
{
    public class PassengerViewModel
    {
        //public int Id { get; set; }
        [Display(Name ="First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }
        [Display(Name = "Source")]
        public string SourcePlace { get; set; }
        [Display(Name = "Destination")]
        public string DestinationPlace { get; set; }
        [Display(Name = "Travel Date")]
        public Nullable<System.DateTime> DateOfTravel { get; set; }
        [Display(Name = "Adhar Card")]
        public string AdharCard { get; set; }
        //public Nullable<System.DateTime> CreatedDt { get; set; }
    }
}