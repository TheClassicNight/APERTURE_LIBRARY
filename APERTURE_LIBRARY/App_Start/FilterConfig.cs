using System.Web;
using System.Web.Mvc;

namespace APERTURE_LIBRARY
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
