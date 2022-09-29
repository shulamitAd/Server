using System;
using System.Data.Entity;
using EFModel;
using EFModel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class TestLogger_Test
    {
        [TestMethod]
        public void AddLog_Test()
        {
            var mockSet = new Mock<DbSet<Log>>();

            var mockContext = new Mock<ProjectContext>();
            mockContext.Setup(m => m.Logs).Returns(mockSet.Object);

            var service = new TestLogger(mockContext.Object);
            service.WriteLog("some log");

            mockSet.Verify(m => m.Add(It.IsAny<Log>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
