using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroeneTeam.Web.Enumerators;

namespace GroeneTeam.Web.Controllers
{
    public class BaseController : Controller
    {
        protected void ZetFormulierMelding(string melding, int type, params object[] args)
        {
            ViewData["FormulierMelding"] = string.Format(melding, args);
            ViewData["MeldingType"] = type;
        }
    }
}