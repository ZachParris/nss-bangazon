using Bangazon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bangazon.DAL
{
    public class BangazonContext
    {
        public virtual DbSet<Task> Task { get; set; }
    }
}