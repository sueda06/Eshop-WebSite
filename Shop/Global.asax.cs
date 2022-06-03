using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using DataAccessLayer.Context;
using Shop.Seed;

namespace Shop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DataContext context = new DataContext();
            if (!context.Users.Any())
            {
                    DatabaseSeedManager.Seed(context);
            }
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
