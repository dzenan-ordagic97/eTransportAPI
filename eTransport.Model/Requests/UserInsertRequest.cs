using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eTransport.Model.Requests
{
    public class UserInsertRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
