using DataProvider;
using EFModel;
using Project.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class TestLogger : ILogger
    {
        private ProjectContext m_context;
        public TestLogger(ProjectContext context)
        {
            m_context = context;
        }
        public void WriteLog(string message)
        {
            var provider = new LogProvider(m_context);
            provider.AddLog(message);
            m_context.SaveChanges();
        }
    }
}
