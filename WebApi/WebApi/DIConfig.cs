using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Project.BL;
using Project.BL.Interface;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace WebApi
{
    public class DIConfig
    {
        public static Container Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();


            RegisterContainer(container);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
            return container;
        }

        private static void RegisterContainer(Container container)
        {
            container.Register<IJobBL, JobBL>(Lifestyle.Singleton);
            container.Register<ILogger, Logger>(Lifestyle.Singleton);
        }
    }
}