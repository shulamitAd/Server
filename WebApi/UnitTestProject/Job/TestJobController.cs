using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using EFModel;
using EFModel.CustomEntities;
using EFModel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using WebApi.Controllers;

namespace UnitTestProject
{
    [TestClass]
    public class TestJobController
    {
        [TestMethod]
        public void TestGetChartData()
        {
            var date = DateTime.Today;
            var data = new List<Jobs>()
            {
                new Jobs() {Date = date,ActiveJobs = 1, ComulativeJobView = 10, ComulativePredictedeJobView = 30 },
                new Jobs() {Date = date.AddDays(-1), ActiveJobs = 6, ComulativeJobView = 70, ComulativePredictedeJobView = 80 },
                new Jobs() {Date = date.AddDays(1), ActiveJobs = 87, ComulativeJobView = 34, ComulativePredictedeJobView = 56 },
                new Jobs() {Date = date.AddDays(2), ActiveJobs = 34, ComulativeJobView = 67, ComulativePredictedeJobView = 12 }
            }
            .AsQueryable();

            var mockSet = new Mock<DbSet<Jobs>>();
            mockSet.As<IQueryable<Jobs>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Jobs>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Jobs>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Jobs>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<ProjectContext>();
            mockContext.Setup(c => c.Jobs).Returns(mockSet.Object);

            var testJob = new TestJobBL(mockContext.Object);
            var testLogger = new TestLogger(mockContext.Object);

            var controller = new JobController(testJob, testLogger);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            List<Jobs> jobs;

            FromToModel fromTo = new FromToModel() { From = date, To = date.AddDays(1) };
            var result = controller.GetChartData(fromTo);
            Assert.IsTrue(result.TryGetContentValue(out jobs));
            Assert.AreEqual(2, jobs.Count);

            fromTo = new FromToModel() { From = date };
            result = controller.GetChartData(fromTo);
            Assert.IsTrue(result.TryGetContentValue(out jobs));
            Assert.AreEqual(3, jobs.Count);

            fromTo = new FromToModel() { To = date };
            result = controller.GetChartData(fromTo);
            Assert.IsTrue(result.TryGetContentValue(out jobs));
            Assert.AreEqual(2, jobs.Count);

            fromTo = new FromToModel();
            result = controller.GetChartData(fromTo);
            Assert.IsTrue(result.TryGetContentValue(out jobs));
            Assert.AreEqual(4, jobs.Count);
        }
    }
}
