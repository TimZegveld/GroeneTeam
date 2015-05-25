using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Html
{
    public static class GroeneTeamHtmlHelper
    {
        public static MvcHtmlString BootstrapIcon(this HtmlHelper html, string icoonNaam)
        {
            return new MvcHtmlString(string.Format("<span class=\"glyphicon glyphicon-{0}\"></span>", icoonNaam));
        }
    }
}
