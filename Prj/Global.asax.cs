using StructureMap.Web.Pipeline;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TSSN.FTE.Insurance.Data.Context;
using TSSN.FTE.Insurance.IocConfig;
using TSSN.FTE.Insurance.Web.Common.CustomModelBinders;
using TSSN.FTE.Insurance.Web.CustomModelBinders;

namespace TSSN.FTE.Insurance.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //WebApiConfig.Register(GlobalConfiguration.Configuration);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            startupConfig();
            
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            HttpContextLifecycle.DisposeAndClearAll();
        }

        public class StructureMapControllerFactory : DefaultControllerFactory
        {
            protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
            {
                if (controllerType == null)
                    throw new InvalidOperationException(string.Format("Page not found: {0}", requestContext.HttpContext.Request.RawUrl));
                return SmObjectFactory.Container.GetInstance(controllerType) as Controller;
            }
        }

        private void startupConfig()
        {
            //Set current Controller factory as StructureMapControllerFactory
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            Microsoft.AspNet.SignalR.GlobalHost.DependencyResolver = SmObjectFactory.Container.GetInstance<Microsoft.AspNet.SignalR.IDependencyResolver>();

            //set current Filter factory as StructureMapFitlerProvider
            var filterProvider = FilterProviders.Providers.Single(provider => provider is FilterAttributeFilterProvider);
            FilterProviders.Providers.Remove(filterProvider);
            FilterProviders.Providers.Add(SmObjectFactory.Container.GetInstance<StructureMapFilterProvider>());

            // Lets MVC know that anytime there is a JQueryDataTablesModel as a parameter in an action to use the
            // JQueryDataTablesModelBinder when binding the model.
            ModelBinders.Binders.Add(typeof(JQueryDataTablesModel), new JQueryDataTablesModelBinder());

            ModelBinders.Binders.Add(typeof(DateTime), new PersianDateModelBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new PersianDateModelBinder());
        }

    }
}
