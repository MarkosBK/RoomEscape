using ASP_ComplexEx.Controllers;
using ASP_ComplexEx.Models;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_ComplexEx.Utils
{
    public class AutofacRegistration
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<RoomsList>().As<IRepository<Room>>().WithParameter("name", "RoomEscape");
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}