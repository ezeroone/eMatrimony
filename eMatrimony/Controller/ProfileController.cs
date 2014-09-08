using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using eMatrimony.BLL.Model;
using eMatrimony.DAL;
using eMatrimony.Model;

namespace eMatrimony.Controller
{
    public class ProfileController : ApiController
    {

        private BLL.Services.ProfileService profileService;

        public ProfileController()
        {
            profileService = new BLL.Services.ProfileService(new EMatrimonyContext());
        }

        [HttpPost]
        public async Task<BaseResponse> Post(ProfileViewModel model)
        {
            
            Mapper.CreateMap<ProfileViewModel, DAL.Profile>();
            var profile = Mapper.Map<ProfileViewModel, DAL.Profile>(model);
            
            var result  = await profileService.CreateNewProfile(new CreateNewProfileModel()
            {
                Password = model.Password,
                Profile = profile
            });

            return result;
        }

    }
}
