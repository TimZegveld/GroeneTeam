using System;
using System.Web.Mvc;
using GroeneTeam.BLL;
using GroeneTeam.Web.Attributes;
using JemId.Basis.BLL;

namespace GroeneTeam.Web.Controllers
{
    [CustomAuthorize]
    public class EvenementController : BaseController
    {
        public ActionResult Index()
        {
            var deelnemer = new Deelnemer(Gebruiker.Current.ID);
            if (!deelnemer.MagHosten)
                return RedirectToAction("MyCrawls");

            var evenementen = Evenement.GeefLijst();
            return View(evenementen);
        }

        public ActionResult MyCrawls()
        {
            var evenementen = Deelnemer.Current.Evenementen;
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