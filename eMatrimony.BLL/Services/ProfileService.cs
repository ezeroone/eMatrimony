using System.Data.Entity;
using System.Threading.Tasks;
using eMatrimony.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eMatrimony.BLL.Services
{
    public class ProfileService
    {
        private DbContext eMatrimonyContext;
        private UserManager<Profile> userManager;

        public ProfileService(DbContext eMatrimonyContext)
        {
            this.eMatrimonyContext = eMatrimonyContext;
            userManager = new UserManager<Profile>(new UserStore<Profile>(eMatrimonyContext));
        }

        public async Task<bool> CreateNewProfile(Profile profile, string password)
        {
            var result = await userManager.CreateAsync(profile, password);
            return result.Succeeded;
        }

    }
}
