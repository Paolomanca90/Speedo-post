using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U4_W5_D1_5.Models
{
    public class SpedizionePrivato
    {
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Mittente { get; set; }

        [Display(Name = "Città Destinatario")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string CittaDestinatario { get; set; }

        [Display(Name = "Indirizzo Destinatario")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string IndirizzoDestinatario { get; set; }

        [Display(Name = "Nome Destinatario")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string NomeDestinatario { get; set; }

        [Display(Name = "Cognome Destinatario")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string CognomeDestinatario { get; set; }

        [Display(Name = "Peso Parcel")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public decimal Peso { get; set; }

        public decimal Costo { get; set; }

        [Display(Name = "Data Spedizione")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public DateTime DataSpedizione { get; set; }

        [Display(Name = "Data Consegna")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public DateTime dataConsegna { get; set; }

        public string NumeroParcel { get; set; }
        //public string Stato { get; set; }
    }

    public class SpedizioneAzienda
    {
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Azienda { get; set; }

        [Display(Name = "Città Destinatario")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string CittaDestinatario { get; set; }

        [Display(Name = "Indirizzo Destinatario")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string IndirizzoDestinatario { get; set; }

        [Display(Name = "Nome Destinatario")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string NomeDestinatario { get; set; }

        [Display(Name = "Cognome Destinatario")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string CognomeDestinatario { get; set; }

        [Display(Name = "Peso Parcel")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public decimal Peso { get; set; }

        public decimal Costo { get; set; }

        [Display(Name = "Data Spedizione")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public DateTime DataSpedizione { get; set; }

        [Display(Name = "Data Consegna")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public DateTime dataConsegna { get; set; }

        public string NumeroParcel { get; set; }
        //public string Stato { get; set; }
    }
}