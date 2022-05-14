using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common_Layer.Users
{
    public class UserPostModel
    {
        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]{2,}$", ErrorMessage = "Name should be Minimum three character,First letter should be capital")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]{2,}$", ErrorMessage = "LastName should be Minimum three character,First letter should be capital")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[a-z]{3,}[0-9]{1,})@gmail.com$", ErrorMessage = "Please Enter valid Email Address")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[A-Z]{1,}[a-z]{1,}(!@#$)[0-9]{1,0}$", ErrorMessage = "Passward Reqire minimum one Capital,three small letter,two small letter,one special character and two numerical")]
        public string Password { get; set; }
    }
}
