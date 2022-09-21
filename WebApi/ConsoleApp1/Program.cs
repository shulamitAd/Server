using EFModel;
using EFModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ProjectContext())
            {
                // Create and save a new Blog
               
                var f = db.Jobs.ToList();
                var blog = new Jobs() { Date = DateTime.Now, ActiveJobs = 2, ComulativeJobView = 45, ComulativePredictedeJobView = 10 };
                db.Jobs.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database
                
            }
        }
    }
}
