using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

namespace EcommerceApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User Name is required", AllowEmptyStrings = false)]
       
        public string UserName { get; set; }

        
        [Required(ErrorMessage = "Password required.", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}