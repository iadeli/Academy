using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Persistence.EF.Tools
{
    internal class AcademyContextFactory : IDbContextFactory<AcademyContext>
    {
        public AcademyContext Create()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            return new AcademyContext(connection);
        }
    }
}
