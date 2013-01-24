using System.Web.Http;
using System.Web.Http.Data.EntityFramework;
using System.Web.Mvc;
using System.Web.Routing;

namespace AgileFreaks.Controllers
{
    public partial class AgileFreaksController : DbDataController<Models.AgileFreaksContext>
    {
        // Any code added here will apply to all entity types managed by this data controller
    }

    // This provides context-specific route registration
    public class AgileFreaksRouteRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "AgileFreaks"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
			RouteTable.Routes.MapHttpRoute(
                "AgileFreaks", // Route name
                "api/AgileFreaks/{action}", // URL with parameters
                new { controller = "AgileFreaks" } // Parameter defaults
            );
        }
    }
}
