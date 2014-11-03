using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using eMatrimony.Action;
using eMatrimony.BLL.Model;
using eMatrimony.BLL.Services;
using eMatrimony.DAL;
using eMatrimony.Model;
using FileResult = eMatrimony.Model.FileResult;

namespace eMatrimony.Controller
{
    [System.Web.Http.RoutePrefix("api/profile")]
    public class ProfileController : ApiController
    {
        private BLL.Services.ProfileService profileService;
        private BLL.Services.LookupService lookupService;
        private string _serverUploadFolder;

        public ProfileController()
        {
            var context = new EMatrimonyContext();
            profileService = new ProfileService(context);
            lookupService = new LookupService(context);
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

        [System.Web.Http.Route("files")]
        [System.Web.Http.HttpPost]
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

        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<ProfileViewModel>> GetProfiles()
        {
            Mapper.CreateMap<DAL.Profile, ProfileViewModel>();
            var profiles = await profileService.GetProfiles();
            var list = Mapper.Map<IEnumerable<DAL.Profile>, IEnumerable<ProfileViewModel>>(profiles);
            return list;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Lookup")]
        public async Task<object> GetLookups()
        {
            var lookup = new
            {
                countries = await lookupService.GetCountries(),
                educationLevels = await lookupService.GetEducationLevel(),
                tongues = await lookupService.GetTongues(),
                religions = await lookupService.GetReligions()
            };

            return Json(lookup);
        }

    }
}
