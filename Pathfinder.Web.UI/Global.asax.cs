﻿using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Pathfinder.Data;
using Pathfinder.Dependency;
using Pathfinder.Dependency.CastleWindsor;
using Pathfinder.Domain;
using Pathfinder.Log;
using Pathfinder.Security;
using Pathfinder.Web.UI.Data;

namespace Pathfinder.Web.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);

            DataContext.Instance.FileStorage = new AppDataFileStorage();

            DI.SetResolver(new CastleWindsorDependencyResolver());
        }
    }
}