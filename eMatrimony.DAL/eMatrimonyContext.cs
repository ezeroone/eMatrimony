using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eMatrimony.DAL
{
    public class EMatrimonyContext : IdentityDbContext<Profile>
    {
        public EMatrimonyContext() : base("DefaultConnection")
        {
        }
    }
}
