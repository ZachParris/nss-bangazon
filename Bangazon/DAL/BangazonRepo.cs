using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bangazon.Models;

namespace Bangazon.DAL
{
    public class BangazonRepo
    {
        public BangazonContext Context;

        public BangazonRepo(BangazonContext _ctx)
        {
            Context = _ctx;
        }
        public BangazonRepo()
        {
            Context = new BangazonContext();
        }

        public object GetTasks()
        {
            return Context.Tasks.ToList();
        }

        public void AddTask(BangazonTask new_task)
        {
            Context.Tasks.Add(new_task);
            Context.SaveChanges();
        }

        public void UpdateTask(string name, string description, string status)
        {

        }

        public void CompletedOn()
        {

        }

    }
}
