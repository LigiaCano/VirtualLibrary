using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VirtualLibrary.Config;

namespace VirtualLibrary
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public object NHibernateHelper { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var schemaUpdate = new SchemaUpdate(NHibernateSession.Configuration);
            schemaUpdate.Execute(Console.WriteLine, true);
        }
    }
}
