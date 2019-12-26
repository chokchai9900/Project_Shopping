using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Shopping.Models
{
    public class UserDBModel
    {
        public string _id { get; set; }
        [Required]
        [Display(Name = "UserName ")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6)]
        [Display(Name = "Password ")]
        public string password { get; set; }

        [Display(Name = "First Name ")]
        public string fitst_Name { get; set; }

        [Display(Name = "Last Name ")]
        public string last_Name { get; set; }

        [Display(Name = "First Address ")]
        public string address { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email Address ")]
        public string email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number ")]
        public string phonenumber { get; set; }

        [Display(Name = "User Type: ")]
        public string role { get; set; }

        [Display(Name = "Status ")]
        public string userStatus { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }

    }
}
