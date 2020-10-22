using System.Web;
using System.Web.Mvc;

namespace INSERT_PROCEDURE_WEBABI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
