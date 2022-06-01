using System.Web;
using System.Web.Mvc;

namespace LabBigSchool_LamQuangTruong
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
