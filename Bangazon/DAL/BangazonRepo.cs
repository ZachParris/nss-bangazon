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

    }
}
