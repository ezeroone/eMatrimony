using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using eMatrimony.DAL;

namespace eMatrimony.BLL.Services
{
    public class LookupService : AbstractService
    {
        private DbSet<Country> countries;
        private DbSet<Religion> religions;
        private DbSet<Tongue> tongues;
        private DbSet<EducationLevel> educationLevels;

        public LookupService(DbContext context) : base(context)
        {
            this.countries = eMatrimonyContext.Set<Country>();
            this.religions = eMatrimonyContext.Set<Religion>();
            this.tongues = eMatrimonyContext.Set<Tongue>();
            this.educationLevels = eMatrimonyContext.Set<EducationLevel>();
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await countries.ToListAsync();
        }

        public async Task<IEnumerable<Religion>> GetReligions()
        {
            return await religions.ToListAsync();
        }

        public async Task<IEnumerable<Tongue>> GetTongues()
        {
            return await tongues.ToListAsync();
        }

        public async Task<IEnumerable<EducationLevel>> GetEducationLevel()
        {
            return await educationLevels.ToListAsync();
        }

    }
}
