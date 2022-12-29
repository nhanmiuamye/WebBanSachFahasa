using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebBanSachFahasa.App_Start;

namespace WebBanSachFahasa
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public void Session_Start()
        {
            Session["log"] = false;
            Session["GioHang"] = false;
            Session["Ho"] = "";
            Session["Ten"] = "";
            Session["SDT"] = "";
            Session["Email"] = "";
            Session["KM"] = null;
            Session["doc"] = true;
            Session["ngang"] = false;
            Session["Tk"] = "";
            Session["logad"] = false;
            Session["maad"] = null;
            Session["HTKM"] = 0;
            Session["MAKHM"] = "";
            Session["erro"] = "";
            Session["bao_cao"] = "";
        }
    }
}
