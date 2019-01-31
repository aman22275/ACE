using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using DF.ACE.Authorization;
using DF.ACE.Controllers;
using DF.ACE.Users;
using DF.ACE.Web.Models.Users;
using DF.ACE.Web.Models.Profile;
using Abp.Domain.Repositories;
using DF.ACE.AdditionalUserProfile;
using DF.ACE.AdditionalUserProfile.Dto;

namespace DF.ACE.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : ACEControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IAdditionalUserProfileAppService _additionalUserProfileService;

        public UsersController(IUserAppService userAppService, IAdditionalUserProfileAppService additionalUserProfileService)
        {
            _userAppService = userAppService;
            _additionalUserProfileService = additionalUserProfileService;
        }

        public async Task<ActionResult> Index()
        {
            var users = (await _userAppService.GetAll(new PagedResultRequestDto {MaxResultCount = int.MaxValue})).Items; // Paging not implemented yet
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EntireUserModel //UserListViewModel
            {
                
                //Users = users,
                //Roles = roles
            };
            model.UserListViewModel = new UserListViewModel();
            model.EditAdditionalUserProfileModel = new EditAdditionalUserProfileModel();
            model.UserListViewModel.Users = users;
            model.UserListViewModel.Roles = roles;
            return View(model);
        }

        public async Task<ActionResult> EditUserModal(long userId)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;

            var additionalUserDataVar = new GetCurrentProfileDataDto();
            additionalUserDataVar.UserId = userId;
            var userAdditionalInfo = await _additionalUserProfileService.GetData(additionalUserDataVar);

            var model = new EditEntireUserModel{};

            model.EditUserModalViewModel = new EditUserModalViewModel();
            model.EditUserModalViewModel.User = user;
            model.EditUserModalViewModel.Roles = roles;

            model.EditAdditionalUserProfileModel = new EditAdditionalUserProfileModel();
            model.EditAdditionalUserProfileModel.AdditionalUserProfile = userAdditionalInfo;

            return View("_EditUserModal", model);
        }      
    }
}
