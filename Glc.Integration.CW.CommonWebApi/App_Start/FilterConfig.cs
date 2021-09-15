using System.Web;
using System.Web.Mvc;

namespace Glc.Integration.CW.CommonWebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
