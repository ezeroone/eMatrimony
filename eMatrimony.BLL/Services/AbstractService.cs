using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMatrimony.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eMatrimony.BLL.Services
{
    public abstract class AbstractService
    {
        protected DbContext eMatrimonyContext;

        protected AbstractService(DbContext eMatrimonyContext)
        {
            this.eMatrimonyContext = eMatrimonyContext;
        }
    }
}
