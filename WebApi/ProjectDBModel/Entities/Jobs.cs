using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDBModel.Entities
{
    public class Jobs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ActiveJobs { get; set; }
        public int ComulativeJobView { get; set; }
        public int ComulativePredictedeJobView { get; set; }
    }

    public class ProjectContext : DbContext
    {
        public ProjectContext():base()
        {
            //Database.SetInitializer<ProjectContext>(new CreateDatabaseIfNotExists<ProjectContext>());
        }
        public DbSet<Jobs> Jobs { get; set; }
    }
}
