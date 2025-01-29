using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.DTO
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
    public class UserRegister
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string? role { get; set; } = "user";
    }
}