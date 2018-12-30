using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Academy.Application;
using Academy.Application.Contracts;
using Academy.Domain.Model.CourseCategories;
using Academy.Persistence.EF;
using Academy.Persistence.EF.Repositories;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using Framework.Core;
using Framework.Kendo;

namespace Academy.Config
{
    public class Bootstrapper
    {
        public static WindsorContainer WireUp(Assembly assembly)
        {
            var container = new WindsorContainer();

            container.Register(Component.For<SecurityInterceptor>());

            container.Register(Component.For<IFilterService>()
                .ImplementedBy<KendoFilterService>()
                .LifestyleSingleton());

            //container.Register(Component.For<ICourseCategoryService>()
            //    .ImplementedBy<CourseCategoryService>()
            //    .Interceptors<SecurityInterceptor>()
            //    .LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<CourseCategoryService>()
                .BasedOn<IService>()
                .WithService.FromInterface()
                .Configure(a => a.Interceptors<SecurityInterceptor>())
                .LifestylePerWebRequest());

            //container.Register(Component.For<ICourseCategoryRepository>()
            //    .ImplementedBy<CourseCategoryRepository>()
            //    .LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<CourseCategoryRepository>()
                .BasedOn<IRepository>()
                .WithService.FromInterface()
                .LifestylePerWebRequest());

            container.Register(Component.For<AcademyContext>()
                .LifestylePerWebRequest());

            container.Register(Classes.FromAssembly(assembly)
                .BasedOn<Controller>()
                .LifestylePerWebRequest());

            container.Register(Component.For<DbConnection>().UsingFactoryMethod(a =>
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
                var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            ).LifestylePerWebRequest());

            return container;
        }
    }
}
