using Bangazon.DAL;
using Bangazon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bangazon.Controllers
{
    public class TaskController : ApiController
    {
        BangazonRepo Repo = new BangazonRepo();

        // GET: api/Task - Gets complete list of tasks
        public IEnumerable<BangazonTask> Get()
        {
            return Repo.GetTasks();
        }

        // GET: api/Task/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Task - Checks to see if new task is valid and adds to the database
        [HttpPost]
        public HttpResponseMessage Post([FromBody]BangazonTask value)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Repo.AddTask(value);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT: api/Task/5 - Checks to see if the edit is valid and updates the task
        [HttpPut,Route("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]BangazonTask value)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            Repo.UpdateTask(value);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        // DELETE: api/Task/5 - Removes task from DB based on Id
        public void Delete(int id)
        {
            Repo.RemoveTask(id);
        }
    }
}
