using EFModel;
using EFModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class LogProvider
    {
        private ProjectContext m_context;
        public LogProvider(ProjectContext ctx)
        {
            m_context = ctx;
        }
        public void AddLog(string message)
        {
            m_context.Logs.Add(new Log() { TimeStamp = DateTime.Now, Message = message });
        }
    }
}
