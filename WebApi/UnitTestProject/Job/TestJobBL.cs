using DataProvider;
using EFModel;
using EFModel.CustomEntities;
using EFModel.Entities;
using Moq;
using Project.BL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class TestJobBL : IJobBL
    {

        private ProjectContext m_context;
        public TestJobBL()
        {

        }

        public TestJobBL(ProjectContext context)
        {
            m_context = context;
        }

        public List<Jobs> GetChartData(FromToModel fromTo)
        {
            var dataProvider = new JobDataProvider(m_context);
            return dataProvider.GetChartData(fromTo);
        }
    }
}
