using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroeneTeam.Web.Controllers
{
    /* 
     * In deze class worden actionfilters gedefinieerd die gebruikt kunnen worden om de ModelState
     * tijdelijk op te slaan. Dit is handig als een formulier-afhandelende action doorverwijst naar
     * een andere actie en daarbij z'n modelstate verliest (gebruiker ziet dan geen ValidationSummary).
     * 
     * Gebruik: zet 
     * [ExportModelStateToTempData] 
     * Boven de verwijzende action en
     * [ImportModelStateFromTempData]
     * boven de action waarnaar verwezen wordt en waar je de ValidationSummary in wilt tonen
     *
     * Update: ViewData["FormulierMelding"] wordt ook tijdelijk opgeslagen. Deze is bedoeld om meldingen
     * in op te slaan die aangeven dat de actie is gelukt.
    */

    public abstract class ModelStateTempDataTransfer : ActionFilterAttribute
    {
        public static readonly string Key = typeof(ModelStateTempDataTransfer).FullName;
    }

    public class ImportExportModelState : ModelStateTempDataTransfer
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            new ImportModelStateFromTempData().OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            new ExportModelStateToTempData().OnActionExecuted(filterContext);
        }
    }

    /// <summary> Exporteert de ModelState na het uitvoeren van de Action naar de TempDataDictionary </summary>
    public class ExportModelStateToTempData : ModelStateTempDataTransfer
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Exporteren als we Redirect gebruiken
            if (filterContext.Result is RedirectResult || filterContext.Result is RedirectToRouteResult || filterContext.Result is EmptyResult)
            {
                // Alleen exporteren als er ModelStateErrors zijn
                ModelStateDictionary modelState = filterContext.Controller.ViewData.ModelState;
                if (!modelState.IsValid)
                {
                    var formCollection = new FormCollection(HttpContext.Current.Request.Form);
                    foreach (string key in formCollection.Keys)
                        modelState.SetModelValue(key, formCollection.GetValue(key));

                    filterContext.Controller.TempData[Key] = modelState;
                }

                filterContext.Controller.TempData["FormulierMelding"] = filterContext.Controller.ViewData["FormulierMelding"];
                filterContext.Controller.TempData["MeldingType"] = filterContext.Controller.ViewData["MeldingType"];
                //filterContext.Controller.TempData["FormNaam"] = filterContext.Controller.ViewData["FormNaam"];
            }

            base.OnActionExecuted(filterContext);
        }
    }

    /// <summary> Importeert de ModelState uit de TempDataDictionary voordat de Action wordt uitgevoerd </summary>
    public class ImportModelStateFromTempData : ModelStateTempDataTransfer
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ModelStateDictionary modelState = filterContext.Controller.TempData[Key] as ModelStateDictionary;

            if (modelState != null)
                filterContext.Controller.ViewData.ModelState.Merge(modelState);

            filterContext.Controller.ViewData["FormulierMelding"] = filterContext.Controller.TempData["FormulierMelding"];
            filterContext.Controller.ViewData["MeldingType"] = filterContext.Controller.TempData["MeldingType"];
            //filterContext.Controller.ViewData["FormNaam"] = filterContext.Controller.TempData["FormNaam"];

            base.OnActionExecuting(filterContext);
        }
    }
}