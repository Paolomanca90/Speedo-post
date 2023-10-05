using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U4_W5_D1_5.Models
{
    public class Dettaglio
    {
        [Display(Name = "Data Modifica")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public DateTime DataModifica { get; set; }

        [Display(Name = "Luogo Modifica")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string LuogoModifica { get; set; }

        [Display(Name = "Stato")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string StatoModifica { get; set; }
        public string NumeroParcel { get; set; }
    }
}