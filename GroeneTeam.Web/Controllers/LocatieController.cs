using System.Linq;
using System.Web.Mvc;
using GroeneTeam.BLL;

namespace GroeneTeam.Web.Controllers
{
    public class LocatieController : Controller
    {
        public ActionResult Index()
        {
            var locaties = Locatie.GeefLijst().OrderBy(l => l.Naam).ToList();
            return View(locaties);
        }

        public ActionResult Bewerk(int? id)
        {
            var locatie = new Locatie(id.GetValueOrDefault());
            return View(locatie);
        }

        [HttpPost]
        public ActionResult Bewerk(int? id, string txtNaam, string txtAdres, string txtPostcode, string txtPlaats)
        {
            var locatie = new Locatie(id.GetValueOrDefault());
            locatie.Opslaan(txtNaam, txtAdres, txtPostcode, txtPlaats);

            return RedirectToAction("Index");
        }

        public ActionResult Verwijder(int? id)
        {
            var locatie = new Locatie(id.GetValueOrDefault());
            locatie.Verwijderen();

            return RedirectToAction("Index");
        }
    }
}