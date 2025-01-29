using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.Models
{
    public class User
    {

        [Key]
        public string Username { get; set; }

        public string role { get; set; }
        public string Password { get; set; }
        public string Passkey { get; set; }
    }
}