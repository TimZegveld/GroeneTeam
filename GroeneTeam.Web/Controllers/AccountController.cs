using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using GroeneTeam.Web.Enumerators;
using JemId.Basis;
using JemId.Basis.BLL;

namespace GroeneTeam.Web.Controllers
{
    public class AccountController : BaseController
    {
        [ImportModelStateFromTempData]
        public ActionResult Inloggen()
        {
            return View();
        }

        [HttpPost]
        [ExportModelStateToTempData]
        public ActionResult Inloggen(string txtGebruikersnaam, string txtWachtwoord)
        {
            if (txtGebruikersnaam.IsNullOrEmpty())
                ModelState.AddModelError("_FORM", "Gebruikersnaam is verplicht");
            if (txtWachtwoord.IsNullOrEmpty())
                ModelState.AddModelError("_FORM", "Wachtwoord is verplicht");

            if (!ModelState.IsValid)
                return RedirectToAction("Inloggen");

            var gebruiker = new Gebruiker(txtGebruikersnaam);
            if (gebruiker.IsNull())
                return RedirectToAction("Inloggen");

            if (gebruiker.Inloggen(txtWachtwoord.CodeerWachtwoord()))
            {
                ZetFormulierMelding("Gefeliciteerd u bent succesvol ingelog!", (int)FormulierMeldingType.Succes);
                return Redirect("/Account/Inloggen");
            }

            return RedirectToAction("Inloggen");
        }
    }
}