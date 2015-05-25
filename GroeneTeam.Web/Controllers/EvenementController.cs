using System;
using System.Web.Mvc;
using GroeneTeam.BLL;

namespace GroeneTeam.Web.Controllers
{
    public class EvenementController : Controller
    {
        public ActionResult Index()
        {
            var evenementen = Evenement.GeefLijst();
            return View(evenementen);
        }

        public ActionResult Bewerk(int? id)
        {
            var evenement = new Evenement(id.GetValueOrDefault());
            return View(evenement);
        }

        [HttpPost]
        public ActionResult Bewerk(int? id, string txtNaam, string txtOmschrijving, string txtStartTijd, string txtEindTijd, string chkIsOpenbaar, string chkMagUitnodigen)
        {
            var startTijd = Convert.ToDateTime(txtStartTijd);
            var eindTijd = Convert.ToDateTime(txtEindTijd);
            bool isOpenbaar = chkIsOpenbaar == null ? false : chkIsOpenbaar == ("on");
            bool magUitnodigen = chkMagUitnodigen == null ? false : chkMagUitnodigen == ("on");

            var evenement = new Evenement(id.GetValueOrDefault());
            evenement.Opslaan(txtNaam, txtOmschrijving, startTijd, eindTijd, isOpenbaar, magUitnodigen);

            return RedirectToAction("Index");
        }

        public ActionResult Verwijder(int? id)
        {
            var evenement = new Evenement(id.GetValueOrDefault());
            evenement.Verwijderen();

            return RedirectToAction("Index");
        }
    }
}