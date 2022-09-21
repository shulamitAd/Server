using ProjectDBModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDBModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ProjectContext())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();
                var f = db.Jobs.ToList();
                var blog = new Jobs() { Date=DateTime.Now,ActiveJobs=2,ComulativeJobView=45,ComulativePredictedeJobView=10};
                db.Jobs.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Jobs
                            orderby b.Date
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Date);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
