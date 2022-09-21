using DataProvider;
using EFModel;
using EFModel.Entities;
using Project.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    public class JobBL : IJobBL
    {
        public List<Jobs> GetChartData()
        {
            using (var ctx = new ProjectContext())
            {
                var dataProvider = new ChartDataProvider(ctx);
                return dataProvider.GetChartData();
            }
        }
    }
}
