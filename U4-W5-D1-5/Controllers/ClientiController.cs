using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using U4_W5_D1_5.Models;

namespace U4_W5_D1_5.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClientiController : Controller
    {
        public List<SelectListItem> AnagraficaPrivato
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                List<Privato> lista = new List<Privato>();
                lista = DB.getPrivati();
                foreach (Privato p in lista)
                {
                    SelectListItem item = new SelectListItem { Text = $"{p.Cognome}, {p.Nome}", Value = $"{p.CF}" };
                    list.Add(item);
                }
                return list;
            }
        }

        public List<SelectListItem> AnagraficaAziende
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                List<Azienda> lista = new List<Azienda>();
                lista = DB.getAziende();
                foreach (Azienda a in lista)
                {
                    SelectListItem item = new SelectListItem { Text = $"{a.RagioneSociale}", Value = $"{a.PartitaIva}" };
                    list.Add(item);
                }
                return list;
            }
        }

        // GET: Clienti
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCliente()
        {
            return View();
        }

        public ActionResult AddPrivato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPrivato(Privato p)
        {
            if (ModelState.IsValid)
            {
                DB.AddCliente(p);
                TempData["Successo"] = "Cliente aggiunto con successo";
                return RedirectToAction("AddCliente");
            }
            TempData["Errore"] = "Errore durante la procedura";
            return RedirectToAction("AddCliente");
        }

        public ActionResult AddAzienda()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAzienda(Azienda a)
        {
            if (ModelState.IsValid)
            {
                DB.AddAzienda(a);
                TempData["Successo"] = "Cliente aggiunto con successo";
                return RedirectToAction("AddCliente");
            }
            TempData["Errore"] = "Errore durante la procedura";
            return RedirectToAction("AddCliente");
        }

        public ActionResult AddSpedizione()
        {
            return View();
        }

        public ActionResult AddSpedizionePrivato()
        {
            ViewBag.AnagraficaPrivati = AnagraficaPrivato;
            return View();
        }

        [HttpPost]
        public ActionResult AddSpedizionePrivato(SpedizionePrivato s)
        {
            if (ModelState.IsValid)
            {
                DB.AddSpedizionePrivato(s);
                TempData["Successo"] = "Spedizione inserita con successo";
                return RedirectToAction("AddSpedizione");
            }
            TempData["Errore"] = "Errore durante la procedura";
            return RedirectToAction("AddSpedizione");
        }

        public ActionResult AddSpedizioneAzienda()
        {
            ViewBag.AnagraficaAziende = AnagraficaAziende;
            return View();
        }

        [HttpPost]
        public ActionResult AddSpedizioneAzienda(SpedizioneAzienda s)
        {
            if (ModelState.IsValid)
            {
                DB.AddSpedizioneAzienda(s);
                TempData["Successo"] = "Spedizione inserita con successo";
                return RedirectToAction("AddSpedizione");
            }
            TempData["Errore"] = "Errore durante la procedura";
            return RedirectToAction("AddSpedizione");
        }

        public ActionResult GetSpedizioni()
        {
            List<SpedizionePrivato> lista = new List<SpedizionePrivato>();
            lista = DB.GetSpedizioniPrivato();
            List<SpedizioneAzienda> lista1 = new List<SpedizioneAzienda>();
            lista1 = DB.GetSpedizioniAzienda();
            ViewBag.ListaAziende = lista1;
            ViewBag.ListaPrivati = lista;
            return View();
        }

        public ActionResult DeleteSpedPrivato(string id)
        {
            DB.deleteSpedPrivato(id);
            TempData["Eliminazione"] = "La spedizione è stata eliminata con successo.";
            return RedirectToAction("GetSpedizioni");
        }

        public ActionResult DeleteSpedAzienda(string id)
        {
            DB.deleteSpedAzienda(id);
            TempData["Eliminazione"] = "La spedizione è stata eliminata con successo.";
            return RedirectToAction("GetSpedizioni");
        }

        public ActionResult Details(string id)
        {
            List<Dettaglio> lista = new List<Dettaglio>();
            lista = DB.GetDettagli(id);
            return View(lista);
        }

        public ActionResult EditSped()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditSped(Dettaglio d)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DB.EditSped(d);
                    TempData["Successo"] = "Spedizione aggiornata con successo";
                    return RedirectToAction("GetSpedizioni");
                }
                TempData["Errore"] = "Errore durante la procedura";
                return RedirectToAction("GetSpedizioni");
            }
            catch (Exception ex)
            {
                string errore = ex.Message;
                return Redirect("http://google.com");
            }

        }

        public ActionResult Anagrafica()
        {
            List<Privato> lista = new List<Privato>();
            lista = DB.getPrivati();
            ViewBag.Privati = lista;
            List<Azienda> lista1 = new List<Azienda>();
            lista1 = DB.getAziende();
            ViewBag.Aziende = lista1;
            return View();
        }

        public ActionResult EditPrivato(int id)
        {
            List<Privato> lista = new List<Privato>();
            lista = DB.getPrivati();
            Privato selected = new Privato();
            foreach(Privato p in lista)
            {
                if(p.IdCliente == id)
                {
                    selected = p;
                    break;
                }
            }
            return View(selected);
        }

        [HttpPost]
        public ActionResult EditPrivato(Privato p)
        {
            int idC = Convert.ToInt16(TempData["IdCliente"]);
            List<Privato> lista = new List<Privato>();
            lista = DB.getPrivati();
            foreach (Privato privato in lista)
            {
                if (privato.IdCliente == idC)
                {
                    p.IdCliente = privato.IdCliente;
                    break;
                }
            }
            if (ModelState.IsValid)
            {
                DB.EditPrivato(p);
                TempData["Salvataggio"] = "Modifica effettuata";
                return RedirectToAction("Anagrafica");
            }
            else
            {
                ViewBag.MessaggioErrore = "Modifica non riuscita";
                return View();
            }
        }

        public ActionResult EditAzienda(int id)
        {
            List<Azienda> lista = new List<Azienda>();
            lista = DB.getAziende();
            Azienda selected = new Azienda();
            foreach (Azienda p in lista)
            {
                if (p.IdAzienda == id)
                {
                    selected = p;
                    break;
                }
            }
            return View(selected);
        }

        [HttpPost]
        public ActionResult EditAzienda(Azienda p)
        {
            int idC = Convert.ToInt16(TempData["IdAzienda"]);
            List<Azienda> lista = new List<Azienda>();
            lista = DB.getAziende();
            foreach (Azienda azienda in lista)
            {
                if (azienda.IdAzienda == idC)
                {
                    p.IdAzienda = azienda.IdAzienda;
                    break;
                }
            }
            if (ModelState.IsValid)
            {
                DB.EditAzienda(p);
                TempData["Salvataggio"] = "Modifica effettuata";
                return RedirectToAction("Anagrafica");
            }
            else
            {
                ViewBag.MessaggioErrore = "Modifica non riuscita";
                return View();
            }
        }
    }
}