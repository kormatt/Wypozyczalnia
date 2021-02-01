using log4net;
using log4net.Config;
using Projekcior.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Projekcior {
    public class MvcApplication : System.Web.HttpApplication, Ilogger<MvcApplication> {
        protected void Application_Start() {
            Stream log4netconfig_stream = new MemoryStream(Resources.log4net);
            XmlConfigurator.Configure(log4netconfig_stream);

            HostingEnvironment.QueueBackgroundWorkItem(cancel => heartBeat());

            this.GetLog().Info("Application started");

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void heartBeat() {
            while (true) {
                this.GetLog().Debug("Heartbeat of the application");
                Thread.Sleep(10000);
            }
        }
    }
}
