using UserManagement.Application.Model;

namespace UserManagement.Application.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UserManagement.Application.Model.UserManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UserManagement.Application.Model.UserManagementContext context)
        {
            IdentityRole role = CreateadminRole(context);
            CreateadminUser(context, role);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private static void CreateadminUser(UserManagementContext context, IdentityRole role)
        {
            using (var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context)))
            {
                var adminUser = userManager.FindByName("admin");

                if (adminUser == null)
                {
                    adminUser = new IdentityUser("admin");
                    userManager.Create(adminUser, "123456");
                    adminUser.Roles.Add(new IdentityUserRole() {RoleId = role.Id, UserId = adminUser.Id});
                }                
            }
        }

        private static IdentityRole CreateadminRole(UserManagementContext context)
        {
            IdentityRole role;
            using (var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
            {
                role = roleManager.FindByName("admin");

                if (role == null)
                {
                    role = new IdentityRole("admin");
                    roleManager.Create(role);
                }
            }

            return role;
        }
    }
}
