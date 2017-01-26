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

        //Gets complete task list
        public List<BangazonTask> GetTasks()
        {
            return Context.Tasks.ToList();
        }

        //Adds new task to DB
        public void AddTask(BangazonTask new_task)
        {
            Context.Tasks.Add(new_task);
            Context.SaveChanges();
        }

        //Remove single selected task by it's ID
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

        //Edits and Updates selected task by Id, also updates completion date once completed
        public BangazonTask UpdateTask(BangazonTask task)
        {
            BangazonTask found_task = Context.Tasks.SingleOrDefault(t => t.TaskID == task.TaskID);
            if (found_task != null)
            {
                found_task.Name = task.Name;
                found_task.Description = task.Description;
                found_task.OrderStatus = task.OrderStatus;

                if(task.OrderStatus == Status.Complete)
                {
                    found_task.CompletedOn = DateTime.Now;
                }
               
                Context.SaveChanges();
                
            }
            return found_task;
        }

        //Returns list of tasks according to current status
        public List<BangazonTask> GetTaskStatusList(int statusId)
        {
            return Context.Tasks.Where(t => t.OrderStatus == (Status)statusId).ToList();
        }
    }
}
