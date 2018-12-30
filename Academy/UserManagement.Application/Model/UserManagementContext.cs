using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;

namespace UserManagement.Application.Model
{
    public class UserManagementContext : IdentityDbContext
    {
        public UserManagementContext(DbConnection connection) : base(connection, false)
        {
            Database.SetInitializer<UserManagementContext>(null);
        }
    }
}
