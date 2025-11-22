using System.Web;
using System.Web.Mvc;

namespace _03_Crud_Manually
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
