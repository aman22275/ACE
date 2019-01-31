
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DF.ACE.Users;
using Abp.Application.Services.Dto;
using DF.ACE.Web.Models.Profile;
using DF.ACE.Controllers;
using System;
using DF.ACE.AdditionalUserProfile;
using DF.ACE.AdditionalUserProfile.Dto;

namespace DF.ACE.Web.Controllers
{
    public class ProfileController : ACEControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IAdditionalUserProfileAppService _additionalUserProfileService;
        

        public ProfileController(IUserAppService userAppService, 
            IAdditionalUserProfileAppService additionalUserProfileService)
        {
            _userAppService = userAppService;
            _additionalUserProfileService = additionalUserProfileService;
        }

        public async Task<ActionResult> EditProfileModal(long userId)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));

            var additionalUserDataVar = new GetCurrentProfileDataDto();
            additionalUserDataVar.UserId = userId;
            var userAdditionalInfo = await _additionalUserProfileService.GetData(additionalUserDataVar);

            var profile = _additionalUserProfileService.GetProfile((long)userId);


            var model = new EditEntireProfileModel { };

            model.ProfilePictureModel = new ProfilePictureModel
            {
                ProfileAttachment = profile
            };

            model.EditProfileModel = new EditProfileModel
            {
                User = user
                
            };

            model.EditAdditionalUserProfileModel = new EditAdditionalUserProfileModel();
            model.EditAdditionalUserProfileModel.AdditionalUserProfile = userAdditionalInfo;
            
            return View("_EditProfile", model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProfilePicture input)
        {
            await _additionalUserProfileService.Upload(input);
            /* var model = new ProfilePictureViewModel
             {
                 profilePicture = m
             };*/
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> EditAdditionalUserProfileModal(long userId)
        {
            var id = new GetCurrentProfileDataDto();
            id.UserId = (int)userId;
            var additionalUserProfile = await _additionalUserProfileService.GetData(id);
            var model = new EditAdditionalUserProfileModel
            {
                AdditionalUserProfile = additionalUserProfile
            };
            return View("_EditAdditionalUserProfile", model);
        }

    }
}