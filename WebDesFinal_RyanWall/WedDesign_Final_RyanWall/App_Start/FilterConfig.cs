using System.Web;
using System.Web.Mvc;

namespace WedDesign_Final_RyanWall
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
