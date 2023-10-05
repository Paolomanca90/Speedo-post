using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U4_W5_D1_5.Models
{
    public class Azienda
    {
        [Display(Name = "Ragione Sociale")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string RagioneSociale { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Sede { get; set; }

        [Display(Name = "Città")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Citta { get; set; }

        [Display(Name = "Partita Iva")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public int PartitaIva { get; set; }
    }
}