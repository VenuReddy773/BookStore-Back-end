using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer.Service.usermodel
{
    public class Login
    {
        [Required]
        public string EmailId { get; set;}
        [Required]
        public string Password { get; set;}
    }
}
