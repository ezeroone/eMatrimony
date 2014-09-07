using System.Web.ApplicationServices;
using System.Web.Http;
using AutoMapper;
using eMatrimony.BLL.Services;
using eMatrimony.DAL;
using eMatrimony.Model;

namespace eMatrimony.Controller
{
    public class ProfileController : ApiController
    {

        private BLL.Services.ProfileService profileService;

        public ProfileController()
        {
            profileService = new eMatrimony.BLL.Services.ProfileService(new EMatrimonyContext());
        }

        [HttpPost]
        public bool Post(ProfileViewModel model)
        {
            Mapper.CreateMap<ProfileViewModel, DAL.Profile>();
            var profile = Mapper.Map<ProfileViewModel, DAL.Profile>(model);
            bool result = profileService.CreateNewProfile(profile, model.Password).Result;
            return result;
        }

    }
}
