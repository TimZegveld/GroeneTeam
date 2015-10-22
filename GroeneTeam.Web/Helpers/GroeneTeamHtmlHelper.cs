using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JemId.Basis;
using GroeneTeam.Web.Enumerators;

namespace System.Web.Mvc.Html
{
    public static class GroeneTeamHtmlHelper
    {
        public static MvcHtmlString BootstrapIcon(this HtmlHelper html, string icoonNaam)
        {
            return new MvcHtmlString(string.Format("<span class=\"glyphicon glyphicon-{0}\"></span>", icoonNaam));
        }

        #region ErrorHandling

        //public static HtmlString FormulierSuccesMelding(this HtmlHelper htmlHelper)
        //{ return htmlHelper.FormulierMelding(FormulierMeldingType.Succes); }

        //public static HtmlString FormulierWarningMelding(this HtmlHelper htmlHelper)
        //{ return htmlHelper.FormulierMelding(FormulierMeldingType.Warning); }

        public static HtmlString FormulierMelding(this HtmlHelper htmlHelper, string melding = "")
        {
            if (melding.IsNullOrEmpty())
                melding = (string)htmlHelper.ViewData["FormulierMelding"];

            var type = (FormulierMeldingType)(htmlHelper.ViewData["MeldingType"] != null ? (int)htmlHelper.ViewData["MeldingType"] : 0);

            if (string.IsNullOrEmpty(melding) || type == FormulierMeldingType.Onbekend)
                return null;

            StringBuilder s = new StringBuilder();

            s.AppendFormat("<div class=\"alert alert-{0} alert-dismissible\" role=\"alert\">", type.ToString().ToLower());
            s.AppendFormat("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>");
            s.AppendFormat("<strong>{0}!</strong> {1}", type.ToString(), melding);
            s.AppendLine("</div>");

            return new HtmlString(s.ToString());
        }

        public static HtmlString JemValidationSummary(this HtmlHelper htmlHelper, string melding = "Ongeldige formulierinvoer:")
        {
            StringBuilder s = new StringBuilder();

            foreach (ModelState modelState in htmlHelper.ViewData.ModelState.Values)
            {
                foreach (ModelError e in modelState.Errors)
                    s.AppendFormat("<li>{0}</li>", e.ErrorMessage);
            }

            if (s.Length > 0)
                return new HtmlString(string.Format("{0}{1}", htmlHelper.FormulierMelding(string.Format("<span>{0}</span><ul>{1}</ul>", melding, s))));

            return new HtmlString(string.Format("{0}{1}", htmlHelper.FormulierMelding(), s));
        }

        #endregion
    }
}
