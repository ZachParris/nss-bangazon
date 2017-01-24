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

        public List<BangazonTask> GetTasks()
        {
            return Context.Tasks.ToList();
        }

        public void AddTask(BangazonTask new_task)
        {
            Context.Tasks.Add(new_task);
            Context.SaveChanges();
        }

        public BangazonTask RemoveTask(int task_id)
        {
            BangazonTask found_task = Context.Tasks.FirstOrDefault(t => t.TaskID == task_id);
            if (found_task != null)
            {
                Context.Tasks.Remove(found_task);
                Context.SaveChanges();
            }
            return found_task;
        }

        public BangazonTask UpdateTask(BangazonTask task)
        {
            BangazonTask found_task = Context.Tasks.SingleOrDefault(t => t.TaskID == task.TaskID);
            if (found_task != null)
            {
                found_task.Name = task.Name;
                found_task.Description = task.Description;
                found_task.OrderStatus = task.OrderStatus;

                Context.SaveChanges();
                
            }
            return found_task;
        }
    }
}
