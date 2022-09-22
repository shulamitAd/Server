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

        //static string connectionString = "";
        //static ProjectContext()
        //{
        //    connectionString = "Data Source=DESKTOP-4PT3KBP\\DEV;Initial Catalog=Project3;Integrated Security=True";
        //}
        public ProjectContext():base()
        {

        }

        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
    }
}
