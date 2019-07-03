using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_5Temp.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int id { get; set; }
        [Display(Name ="Full Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Invalid Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name ="Email Address")]
        public string Email { get; set; }
        [Display(Name="Mobile Numer")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        public string Phone { get; set; }
        [Display(Name ="Home Address")]
        public string Address { get; set; }
    }
}