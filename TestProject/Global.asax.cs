using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestProject.Models;

namespace Testproject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // JEMO : determine the database initializer for the TestProjectContext to use
            Database.SetInitializer<TestProjectContext>(new TestProjectInitializer());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }



    }
}
