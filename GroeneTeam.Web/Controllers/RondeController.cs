using System.Linq;
using System.Web.Mvc;
using GroeneTeam.BLL;
using GroeneTeam.Web.Extensions;

namespace GroeneTeam.Web.Controllers
{
    public class RondeController : Controller
    {
        public ActionResult Toevoegen(int id)
        {
            var evenement = new Evenement(id);
            var ronde = new Ronde(evenement);
            ronde.Opslaan(30);

            return Redirect("/Ronde/Bewerk/" + ronde.ID);
        }

        public ActionResult Bewerk(int? id)
        {
            var ronde = new Ronde(id.GetValueOrDefault());
            var locaties = Locatie.GeefLijst().OrderBy(l => l.Naam).ToList();

            ViewBag.Locaties = locaties;

            return View(ronde);
        }

        [HttpPost]
        public ActionResult Bewerk(int? id, int txtDoorloopTijd, FormCollection fc)
        {
            var ronde = new Ronde(id.GetValueOrDefault());
            ronde.Opslaan(txtDoorloopTijd);

            var locaties = fc.GeefCheckedValues<Locatie>("chkLocatie", i => new Locatie(i));
            ronde.ZetLocaties(locaties);

            return Redirect("/Evenement/Bewerk/" + ronde.Evenement.ID);
        }

        public ActionResult Verwijder(int? id)
        {
            var ronde = new Ronde(id.GetValueOrDefault());
            ronde.Verwijderen();

            return Redirect("/Evenement/Bewerk/" + ronde.Evenement.ID);
        }

        public ActionResult Omhoog(int id)
        {
            var ronde = new Ronde(id);
            ronde.VolgordeVerlagen();

            return Redirect("/Evenement/Bewerk/" + ronde.Evenement.ID);
        }

        public ActionResult Omlaag(int id)
        {
            var ronde = new Ronde(id);
            ronde.VolgordeVerhogen();

            return Redirect("/Evenement/Bewerk/" + ronde.Evenement.ID);
        }
    }
}