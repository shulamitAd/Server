using DataProvider;
using EFModel;
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

        private IQueryable<Jobs> _data;
        public TestJobBL()
        {

        }

        public TestJobBL(IQueryable<Jobs> data)
        {
            _data = data;
        }

        public List<Jobs> GetChartData()
        {
            var mockSet = new Mock<DbSet<Jobs>>();
            mockSet.As<IQueryable<Jobs>>().Setup(m => m.Provider).Returns(_data.Provider);
            mockSet.As<IQueryable<Jobs>>().Setup(m => m.Expression).Returns(_data.Expression);
            mockSet.As<IQueryable<Jobs>>().Setup(m => m.ElementType).Returns(_data.ElementType);
            mockSet.As<IQueryable<Jobs>>().Setup(m => m.GetEnumerator()).Returns(() => _data.GetEnumerator());

            var mockContext = new Mock<ProjectContext>();
            mockContext.Setup(c => c.Jobs).Returns(mockSet.Object);

            var service = new ChartDataProvider(mockContext.Object);
            return service.GetChartData();
        }
    }
}
