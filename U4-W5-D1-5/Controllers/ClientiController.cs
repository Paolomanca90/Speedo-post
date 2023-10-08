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
    //[Authorize(Roles = "Admin")]
    [Authorize]
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

        [Authorize(Roles = "Admin")]
        public ActionResult AddCliente()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddPrivato()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult AddAzienda()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult AddSpedizione()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddSpedizionePrivato()
        {
            ViewBag.AnagraficaPrivati = AnagraficaPrivato;
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult AddSpedizioneAzienda()
        {
            ViewBag.AnagraficaAziende = AnagraficaAziende;
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteSpedPrivato(string id)
        {
            DB.deleteSpedPrivato(id);
            TempData["Eliminazione"] = "La spedizione è stata eliminata con successo.";
            return RedirectToAction("GetSpedizioni");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteSpedAzienda(string id)
        {
            DB.deleteSpedAzienda(id);
            TempData["Eliminazione"] = "La spedizione è stata eliminata con successo.";
            return RedirectToAction("GetSpedizioni");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Details(string id)
        {
            List<Dettaglio> lista = new List<Dettaglio>();
            lista = DB.GetDettagli(id);
            return View(lista);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditSped()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult DeletePrivato(int id)
        {
            DB.deletePrivato(id);
            TempData["Eliminazione"] = "Utente eliminato con successo.";
            return RedirectToAction("Anagrafica");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteAzienda(int id)
        {
            DB.deletePrivato(id);
            TempData["Eliminazione"] = "Utente eliminato con successo.";
            return RedirectToAction("Anagrafica");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Registri()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetToday()
        {
            List<SpedizionePrivato> lista = new List<SpedizionePrivato>();
            lista = DB.SpedPrivatoOggi(DateTime.Now);
            List<SpedizioneAzienda> lista1 = new List<SpedizioneAzienda>();
            lista1 = DB.SpedAziendaOggi(DateTime.Now);
            var risultato = new
            {
                ListaSpedizioniPrivati = lista,
                ListaSpedizioniAziende = lista1
            };

            return Json(risultato, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetCitta()
        {
            List<SpedizioniTotali> lista = new List<SpedizioniTotali>();
            lista = DB.GetSpedizioniAziendaDestinazione();
            List<SpedizioniTotali> lista1 = new List<SpedizioniTotali>();
            lista1 = DB.GetSpedizioniPrivatoDestinazione();
            lista.AddRange(lista1);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetConsegna()
        {
            List<SpedizioniTotali> lista = new List<SpedizioniTotali>();
            lista = DB.GetSpedizioniAziendaConsegna();
            List<SpedizioniTotali> lista1 = new List<SpedizioniTotali>();
            lista1 = DB.GetSpedizioniPrivatoConsegna();
            lista.AddRange(lista1);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Spedizione()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetSpedizione(string cf, string numeroParcel)
        {
            List<Dettaglio> lista = DB.GetSpedPrivatoByCfParcel(cf,numeroParcel);
            List<Dettaglio> lista1 = DB.GetSpedAziendaByCfParcel(cf, numeroParcel);
            lista.AddRange(lista1);
            return Json(lista);
        }
    }
}