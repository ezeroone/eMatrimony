using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using eMatrimony.BLL.Model;
using eMatrimony.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eMatrimony.BLL.Services
{
    public class ProfileService : AbstractService
    {
        private UserManager<User> userManager;
        private DbSet<Profile> profiles;

        public ProfileService(DbContext eMatrimonyContext): base(eMatrimonyContext)
        {
            userManager = new UserManager<User>(new UserStore<User>(eMatrimonyContext));
            profiles = eMatrimonyContext.Set<Profile>();
        }

        public async Task<BaseResponse> CreateNewProfile(CreateNewProfileModel createNewProfileModel)
        {
            var user = new User()
            {
                Email = createNewProfileModel.Profile.Email,
                UserName = createNewProfileModel.Profile.Email,
            };
            
            var result = await userManager.CreateAsync(user, createNewProfileModel.Password);

            if (result.Succeeded)
            {
                profiles.Add(createNewProfileModel.Profile);
                eMatrimonyContext.SaveChanges();
            }

            return new BaseResponse(result.Succeeded, string.Join(",", result.Errors.ToArray()));
        }

        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            var list = await profiles.ToListAsync();
            return list;
        }

    }
}
