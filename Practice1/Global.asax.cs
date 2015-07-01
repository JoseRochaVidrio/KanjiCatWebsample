using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentSecurity;
using Practice1.Controllers;
using Practice1.Helpers;

namespace Practice1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            SecurityConfigurator.Configure(configuracion =>
            {
                configuracion.GetAuthenticationStatusFrom(() => Helpers.SecurityHelper.UserIsAuthenticated());
                configuracion.DefaultPolicyViolationHandlerIs(() => new Helpers.DefaultPolicyHandler());
                

                configuracion.ForAllControllers().DenyAnonymousAccess();

                configuracion.For<AccountController>().AllowAny();

            });

            GlobalFilters.Filters.Add(new HandleSecurityAttribute(), -1);

        }
    }
}
