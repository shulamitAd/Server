using EFModel;
using EFModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class ChartDataProvider
    {
        private ProjectContext m_context;
        public ChartDataProvider(ProjectContext ctx)
        {
            m_context = ctx;
        }
        public List<Jobs> GetChartData()
        {
            return m_context.Jobs.ToList();
        }
    }
}
