using DataProvider;
using EFModel;
using Project.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    public class Logger : ILogger
    {
        public void WriteLog(string message)
        {
            using (var ctx = new ProjectContext())
            {
                var provider = new LogProvider(ctx);
                provider.AddLog(message);
                ctx.SaveChanges();
            }
        }
    }
}
