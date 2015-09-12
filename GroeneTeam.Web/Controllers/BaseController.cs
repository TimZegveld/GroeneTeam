using System.Web.Mvc;
using GroeneTeam.Web.Enumerators;
using JemId.Basis;

namespace GroeneTeam.Web.Controllers
{
    public class BaseController : Controller
    {
        protected RedirectToRouteResult RedirectToIndex()
        {
            return RedirectToAction("Index");
        }

        protected void ZetFormulierMelding(string melding, FormulierMeldingType type, params object[] args)
        {
            ViewData["FormulierMelding"] = string.Format(melding, args);
            ViewData["MeldingType"] = (int)type;
        }

        /// <summary> Voegt de Message van een opgetreden JemException toe als ModelError aan de ModelState </summary>
        protected void HandleJemException(JemException ex)
        {
            ModelState.AddModelError("_FORM", ex.Message);
        }
    }
}