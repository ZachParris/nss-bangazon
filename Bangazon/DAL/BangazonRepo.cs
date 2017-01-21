using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bangazon.DAL
{
    public class BangazonRepo
    {
        private BangazonContext Context;

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
            return Context.Task.ToList();
        }

        public void CreateNewTask(string new_task)
        {
            Context.Task.Add(new_task).ToString()
        }

        public void UpdateTask(string name, string description, string status)
        {

        }

        public void CompletedOn()
        {

        }

    }
}
