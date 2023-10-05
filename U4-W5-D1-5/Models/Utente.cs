using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U4_W5_D1_5.Models
{
    public class Utente
    {
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}