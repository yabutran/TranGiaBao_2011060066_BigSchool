using System.Web;
using System.Web.Mvc;

namespace _34_TranGiaBao_2011060066
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
