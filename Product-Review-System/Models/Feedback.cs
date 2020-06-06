using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Product_Review_System.Models
{
    public class Feedback
    {
        public int id { get; set; }
        [Required]
        [Display ( Name ="Enter Your Feedback") ]
        public string YourFeedback { get; set; }
    }
}