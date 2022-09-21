using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using EFModel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var data = new List<Jobs>()
            {
                new Jobs() {Date = DateTime.Now,ActiveJobs=1,ComulativeJobView=10,ComulativePredictedeJobView=30}
            }
            .AsQueryable();

            var testJob = new TestJobBL(data);

            var controller = new JobController(testJob);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            var result = controller.GetChartData().Content;

            Assert.IsNotNull(result);
            //Assert.AreEqual(3, result.Local.Count);

        }
    }
}
