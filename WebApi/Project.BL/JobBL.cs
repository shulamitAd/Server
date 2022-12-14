using DataProvider;
using EFModel;
using EFModel.CustomEntities;
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
        public List<Jobs> GetChartData(FromToModel fromTo)
        {
            using (var ctx = new ProjectContext())
            {
                var dataProvider = new JobDataProvider(ctx);
                return dataProvider.GetChartData(fromTo);
            }
        }
    }
}
