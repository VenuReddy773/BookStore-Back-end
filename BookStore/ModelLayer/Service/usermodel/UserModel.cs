using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer.Service
{
    public class UserModel
    {
        public int user_id { get; set; }
        public string FullName { get; set; }
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$",
         ErrorMessage = "Please enter correct email address")]
        public string EmailId { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
         ErrorMessage = "Weak Password")]
        public string Password { get; set; }
        public string MobileNumber { get; set; }
    }
}
