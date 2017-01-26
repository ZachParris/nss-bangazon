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

        // GET: api/Task
        public IEnumerable<BangazonTask> Get()
        {
            return Repo.GetTasks();
        }

        // GET: api/Task/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Task
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

        // PUT: api/Task/5
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

        // DELETE: api/Task/5
        public void Delete(int id)
        {
            Repo.RemoveTask(id);
        }
    }
}
