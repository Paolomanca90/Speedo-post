using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U4_W5_D1_5.Models
{
    public class Privato
    {
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string CF { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Indirizzo { get; set; }

        [Display(Name = "Città")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Citta { get; set; }
    }
}