using EFModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel
{
    public class ProjectContext : DbContext
    {

        static string connectionString = "";
        static ProjectContext()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        }
        public ProjectContext():base(connectionString)
        {

        }

        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
    }
}
