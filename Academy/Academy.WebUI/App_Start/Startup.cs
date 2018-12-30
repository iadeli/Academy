using System;
using System.Web.Mvc;
using System.Web.Routing;
using Academy.Config;
using Academy.WebUI;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Academy.WebUI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            var container = Bootstrapper.WireUp(typeof(Startup).Assembly);
            UserManagement.Config.Bootstrapper.WireUp(container);

            //container.Register(Component.For<CourseCategoriesController>());
            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory(container));
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //GlobalFilters.Filters.Add(new AuthorizeAttribute());

            SetupSecurity(app);
        }

        private void SetupSecurity(IAppBuilder app)
        {
            var options = new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Index"),
                ExpireTimeSpan = TimeSpan.FromDays(30),
                CookieHttpOnly = false
            };
            app.UseCookieAuthentication(options);
        }
    }
}
