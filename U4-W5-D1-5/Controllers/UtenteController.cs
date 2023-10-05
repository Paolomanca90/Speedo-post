using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using U4_W5_D1_5.Models;

namespace U4_W5_D1_5.Controllers
{
    public class UtenteController : Controller
    {
        // GET: Utente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Utente u)
        {
            if (ModelState.IsValid)
            {
                DB.GetUtente(u);
                if (User.Identity.Name != "")
                {
                    return RedirectToAction("Index", "Clienti");
                }
            }
            TempData["Messaggio"] = "Utente non trovato";
            return RedirectToAction("Index", "Utente");
        }
    }
}