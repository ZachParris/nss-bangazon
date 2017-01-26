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
        private Mock<DbSet<BangazonTask>> mock_tasks; 
        private List<BangazonTask> tasks { get; set; }
        private BangazonRepo Repo { get; set; }
        private Mock<BangazonContext> mock_context { get; set; }

        [TestInitialize]
        public void Intialize()
        {
            mock_context = new Mock<BangazonContext>();
            mock_tasks = new Mock<DbSet<BangazonTask>>();
            Repo = new BangazonRepo(mock_context.Object);
            tasks = new List<BangazonTask>
            {
                new BangazonTask
                {
                    TaskID = 1,
                    Name = "",
                    Description = ""
                },
                new BangazonTask
                {
                    TaskID = 2,
                    Name = "",
                    Description = ""
                }
            };
        }

        public void ConnectToDatastore()
        {
            var query_tasks = tasks.AsQueryable();
            mock_tasks.As<IQueryable<BangazonTask>>().Setup(m => m.Provider).Returns(query_tasks.Provider);
            mock_tasks.As<IQueryable<BangazonTask>>().Setup(m => m.Expression).Returns(query_tasks.Expression);
            mock_tasks.As<IQueryable<BangazonTask>>().Setup(m => m.ElementType).Returns(query_tasks.ElementType);
            mock_tasks.As<IQueryable<BangazonTask>>().Setup(m => m.GetEnumerator()).Returns(() => query_tasks.GetEnumerator());

            mock_context.Setup(c => c.Tasks ).Returns(mock_tasks.Object);
            mock_tasks.Setup(u => u.Add(It.IsAny<BangazonTask>())).Callback((BangazonTask t) => tasks.Add(t));
            mock_tasks.Setup(u => u.Remove(It.IsAny<BangazonTask>())).Callback((BangazonTask t) => tasks.Remove(t));
        }

        [TestMethod]
        public void RepoEnsureCanCreateAnInstance()
        {
            BangazonRepo repo = new BangazonRepo();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void AddATaskToTasksList()
        {
            ConnectToDatastore();

            BangazonTask new_task = new BangazonTask
            {
                TaskID = 1,
                Name = "Some task",
                Description = "Brief description",
                OrderStatus = Status.ToDo,
                CompletedOn = DateTime.Now
            };
            Repo.AddTask(new_task);

            int expected_tasks = 3;
            int actual_tasks = Repo.Context.Tasks.Count();


            Assert.AreEqual(expected_tasks, actual_tasks);
        }

        [TestMethod]
        public void RemoveTaskFromTaskList()
        {
            ConnectToDatastore();
            BangazonTask new_task = new BangazonTask
            {
                TaskID = 1,
                Name = "Some task",
                Description = "Brief description",
                OrderStatus = Status.ToDo,
                CompletedOn = DateTime.Now
            };
            BangazonTask newer_task = new BangazonTask
            {
                TaskID = 2,
                Name = "Some task",
                Description = "Brief description",
                OrderStatus = Status.ToDo,
                CompletedOn = DateTime.Now
            };
            Repo.AddTask(new_task);
            Repo.AddTask(newer_task);

            BangazonTask removed_task = Repo.RemoveTask(2);

            int expected_tasks = 3;
            int actual_tasks = Repo.Context.Tasks.Count();

            Assert.AreEqual(expected_tasks, actual_tasks);
        }

        [TestMethod]
        public void EditTaskInTaskList()
        {
            ConnectToDatastore();

            BangazonTask task = new BangazonTask
            {
                TaskID = 1,
                Name = "Updated task",
                Description = "Brief description",
                OrderStatus = Status.ToDo,
                CompletedOn = DateTime.Now
            };

            Repo.UpdateTask(task);

            Assert.IsNotNull(task);
        }

        [TestMethod]
        public void GetTasksByStatus()
        {
            ConnectToDatastore();

            BangazonTask task = new BangazonTask
            {
                TaskID = 1,
                Name = "Updated task",
                Description = "Brief description",
                OrderStatus = Status.Complete,
                CompletedOn = DateTime.Now
            };
            Repo.AddTask(task);

            int expected = 1;
            int actual = Repo.GetTaskStatusList(2).Count();

            Assert.AreEqual(expected, actual);
            
        }

    }
}
