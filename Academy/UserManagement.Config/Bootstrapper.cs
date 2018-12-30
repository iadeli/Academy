using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application;
using UserManagement.Application.Contracts;
using UserManagement.Application.Model;

namespace UserManagement.Config
{
    public class Bootstrapper
    {
        public static void WireUp(IWindsorContainer container)
        {
            container.Register(Component.For<IAuthenticationService>()
                .ImplementedBy<AuthenticationService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<UserManager<IdentityUser>>()
                .UsingFactoryMethod(c => CreateUserManager(c))
                .LifestylePerWebRequest());

            container.Register(Component.For<UserManagementContext>().LifestylePerWebRequest());
        }

        private static UserManager<IdentityUser> CreateUserManager(IKernel kernel)
        {
            var context = kernel.Resolve<UserManagementContext>();
            return new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
        }
    }
}
