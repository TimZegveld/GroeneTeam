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
        [ImportModelStateFromTempData]
        public ActionResult Index()
        {
            if (!Deelnemer.Current.MagHosten)
                return RedirectToAction("MyCrawls");

            var evenementen = Evenement.GeefLijstBeheer(Deelnemer.Current);
            return View(evenementen);
        }

        public ActionResult MyCrawls()
        {
            return View(Deelnemer.Current.Evenementen);
        }

        public ActionResult Bewerk(int? id)
        {
            var evenement = new Evenement(id.GetValueOrDefault());
            return View(evenement);
        }

        [HttpPost]
        [ExportModelStateToTempData]
        public ActionResult Bewerk(int? id, string txtNaam, string txtOmschrijving, string txtStartTijd, string txtEindTijd, string chkIsOpenbaar, string chkMagUitnodigen)
        {
            var startTijd = Convert.ToDateTime(txtStartTijd);
            var eindTijd = Convert.ToDateTime(txtEindTijd);
            bool isOpenbaar = chkIsOpenbaar == null ? false : chkIsOpenbaar == ("on");
            bool magUitnodigen = chkMagUitnodigen == null ? false : chkMagUitnodigen == ("on");

            var evenement = new Evenement(id.GetValueOrDefault());
            evenement.Opslaan(txtNaam, txtOmschrijving, startTijd, eindTijd, isOpenbaar, magUitnodigen);

            ZetFormulierMelding("Evenement opgeslagen", Enumerators.FormulierMeldingType.Success);
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