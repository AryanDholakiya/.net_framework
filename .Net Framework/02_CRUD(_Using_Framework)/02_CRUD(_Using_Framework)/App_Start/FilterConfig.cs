using System.Web;
using System.Web.Mvc;

namespace _02_CRUD__Using_Framework_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
