using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroeneTeam.BLL;

namespace GroeneTeam.Web.Controllers
{
    public class LocatieController : Controller
    {

        public ActionResult Index()
        {
            var locaties = Locatie.GeefLijst();
            return View(locaties);
        }

        public ActionResult Bewerk(int? id)
        {
            var locatie = new Locatie(id.GetValueOrDefault());
            return View(locatie);
        }

        [HttpPost]
        public ActionResult Bewerk(int? id, string txtNaam, string txtAdres, string txtPostcode, string txtPlaats, string txtLatitude, string txtLongitude)
        {


            //if (!ModelState.IsValid)
            //    return RedirectToReferrer();

            try
            {
                var locatie = new Locatie(id.GetValueOrDefault());
                locatie.Opslaan(txtNaam, txtAdres, txtPostcode, txtPlaats);
            }
            catch (Exception ex) { }

            //   return RedirectToIndex();
            return new EmptyResult();
        }
    }
}