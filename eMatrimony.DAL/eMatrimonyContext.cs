using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eMatrimony.DAL
{
    public class EMatrimonyContext : IdentityDbContext<User>
    {
        public EMatrimonyContext() : base("DefaultConnection")
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Tongue> Tongues { get; set; }
        public DbSet<Religion> Religions { get; set; }

    }
}
