using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using eMatrimony.Action;
using eMatrimony.BLL.Model;
using eMatrimony.DAL;
using eMatrimony.Model;
using FileResult = eMatrimony.Model.FileResult;

namespace eMatrimony.Controller
{
    [RoutePrefix("api/profile")]
    public class ProfileController : ApiController
    {
        private BLL.Services.ProfileService profileService;
        private string _serverUploadFolder;

        public ProfileController()
        {
            profileService = new BLL.Services.ProfileService(new EMatrimonyContext());
            _serverUploadFolder = ConfigurationManager.AppSettings["ServerUploadPath"];
        }

        [System.Web.Http.HttpPost]
        public async Task<BaseResponse> Post(ProfileViewModel model)
        {
            Mapper.CreateMap<ProfileViewModel, DAL.Profile>();
            var profile = Mapper.Map<ProfileViewModel, DAL.Profile>(model);
            var result = await profileService.CreateNewProfile(new CreateNewProfileModel()
            {
                Password = model.Password,
                Profile = profile
            });
            return result;
        }

        [Route("files")]
        [HttpPost]
        [ValidateMimeMultipartContentFilter]
        public async Task<FileResult> UploadSingleFile()
        {
            var streamProvider = new MultipartFormDataStreamProvider(_serverUploadFolder);
            await Request.Content.ReadAsMultipartAsync(streamProvider);

            return new FileResult
            {
                FileNames = streamProvider.FileData.Select(entry => entry.LocalFileName),
                Names = streamProvider.FileData.Select(entry => entry.Headers.ContentDisposition.FileName),
                ContentTypes = streamProvider.FileData.Select(entry => entry.Headers.ContentType.MediaType),
                Description = streamProvider.FormData["description"],
                CreatedTimestamp = DateTime.UtcNow,
                UpdatedTimestamp = DateTime.UtcNow,
                DownloadLink = string.Empty
            };
        }

        [HttpGet]
        public async Task<IEnumerable<ProfileViewModel>> GetProfiles()
        {
            Mapper.CreateMap<DAL.Profile, ProfileViewModel>();
            var profiles = await profileService.GetProfiles();
            var list = Mapper.Map<IEnumerable<DAL.Profile>, IEnumerable<ProfileViewModel>>(profiles);
            return list;
        }

    }
}
