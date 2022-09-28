using EFModel;
using EFModel.CustomEntities;
using EFModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class JobDataProvider
    {
        private ProjectContext m_context;
        public JobDataProvider(ProjectContext ctx)
        {
            m_context = ctx;
        }
        public List<Jobs> GetChartData(FromToModel fromTo)
        {
            return m_context.Jobs.Where(x =>
            (!fromTo.From.HasValue || x.Date >= fromTo.From.Value) &&
            (!fromTo.To.HasValue || x.Date <= fromTo.To.Value))
            .OrderBy(x => x.Date)
            .Take(1000)
                .ToList();
        }
    }
}
