using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bangazon.Models;
using Bangazon.DAL;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bangazon.Tests.DAL
{
    [TestClass]
    public class BangazonRepoTests
    {
        private Mock<DbSet<Task>> mock_tasks; 
        private List<Task> tasks { get; set; }
        private BangazonRepo Repo { get; set; }
        private Mock<BangazonContext> mock_context { get; set; }

        [TestInitialize]
        public void Intialize()
        {
            mock_context = new Mock<BangazonContext>();
            mock_tasks = new Mock<DbSet<Task>>();
            Repo = new BangazonRepo(mock_context.Object);
            tasks = new List<Task>
            {
                new Task
                {
                    TaskID = 1,
                    Name = "",
                    Description = "",
                    OrderStatus = new Status { },
                    CompletedOn = new DateTime { }
                },
                new Task
                {
                    TaskID = 2,
                    Name = "",
                    Description = "",
                    OrderStatus = new Status { },
                    CompletedOn = new DateTime { }
                }
            };
        }

        public void ConnectToDatastore()
        {
            var query_tasks = tasks.AsQueryable();
            mock_tasks.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(query_tasks.Provider);
            mock_tasks.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(query_tasks.Expression);
            mock_tasks.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(query_tasks.ElementType);
            mock_tasks.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(() => query_tasks.GetEnumerator());

            mock_context.Setup(c => c.Task).Returns(mock_tasks.Object);
            mock_tasks.Setup(u => u.Add(It.IsAny<Task>())).Callback((Task t) => tasks.Add(t));
            mock_tasks.Setup(u => u.Remove(It.IsAny<Task>())).Callback((Task t) => tasks.Remove(t));
        }

        [TestMethod]
        public void RepoEnsureCanCreateAnInstance()
        {
            BangazonRepo repo = new BangazonRepo();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void GetTasksList()
        {

        }

        [TestMethod]
        public void ()
        {

        }
    }
}
