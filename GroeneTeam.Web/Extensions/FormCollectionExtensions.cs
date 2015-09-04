using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;
using JemId.Basis.BLL;

namespace GroeneTeam.Web.Extensions
{
    public static class FormCollectionExtensions
    {
        public static Dictionary<string, string> ToDictionaryOfStrings(this NameValueCollection collection)
        {
            return collection.AllKeys.ToDictionary(k => k, k => collection[k]);
        }

        public static List<TBll> GeefCheckedValues<TBll>(this FormCollection formCollection, string fieldPrefix, Func<int, TBll> factory)
            where TBll : BusinessLogica
        {
            var result = new List<TBll>();
            var checkedValues = formCollection.ToDictionaryOfStrings().Where(kvp =>
                kvp.Key.StartsWith(fieldPrefix) &&
                kvp.Value == "on");

            foreach (var kvp in checkedValues)
            {
                int bllId = Convert.ToInt32(kvp.Key.Replace(fieldPrefix, string.Empty));
                if (bllId > 0)
                    result.Add(factory(bllId));
            }

            return result;
        }
    }
}
