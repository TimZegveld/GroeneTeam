using System.Web.Mvc;
using GroeneTeam.Web.Attributes;
using GroeneTeam.Web.Enumerators;
using GroeneTeam.Web.Extensions;
using JemId.Basis;
using JemId.Basis.BLL;

namespace GroeneTeam.Web.Controllers
{
    public class AccountController : BaseController
    {
        [CustomAuthorize]
        public ActionResult Index()
        {
            if (Gebruiker.Current.IsNull())
                return RedirectToAction("Inloggen");

            return Redirect("/Evenement/Index");
        }

        [ImportModelStateFromTempData]
        public ActionResult Inloggen() { return View(); }

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
            {
                ZetFormulierMelding("Fout bij inloggen", FormulierMeldingType.Danger);
                return RedirectToAction("Inloggen");
            }

            if (gebruiker.Inloggen(txtWachtwoord.CodeerWachtwoord()))
            {
                Session.ZetGebruiker(gebruiker);

                ZetFormulierMelding("Gefeliciteerd u bent succesvol ingelogd!", FormulierMeldingType.Success);
                return RedirectToIndex();
            }

            return RedirectToAction("Inloggen");
        }

        public virtual ActionResult Uitloggen(string returnUrl)
        {
            try
            {
                var gebruiker = Session.GeefGebruiker();
                if (gebruiker.IsNotNull())
                    gebruiker.Uitloggen();

                Session.Clear();
            }
            catch (JemException e) { HandleJemException(e); }

            if (!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);

            return Redirect("/");
        }
    }
}