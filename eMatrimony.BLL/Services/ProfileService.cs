using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using eMatrimony.BLL.Model;
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

        public async Task<BaseResponse> CreateNewProfile(CreateNewProfileModel createNewProfileModel)
        {
            var result = await userManager.CreateAsync(createNewProfileModel.Profile, createNewProfileModel.Password);
            return new BaseResponse(result.Succeeded, string.Join(",", result.Errors.ToArray()));
        }

    }
}
