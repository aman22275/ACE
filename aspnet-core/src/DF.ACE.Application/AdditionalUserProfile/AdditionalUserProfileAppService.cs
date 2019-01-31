using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using DF.ACE.AdditionalUserProfile.Dto;
using DF.ACE.Authorization.Users;
using DF.ACE.Common.Attachment;
using DF.ACE.Users;
using DF.ACE.Users.Dto;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DF.ACE.AdditionalUserProfile
{

    public class AdditionalUserProfileAppService : AsyncCrudAppService<UserProfile, AdditionalUserProfileDto, int, PagedResultRequestDto, CreateAdditionalUserProfileDto, AdditionalUserProfileDto>, IAdditionalUserProfileAppService

    {
        private readonly IRepository<UserProfile> _userProfile;
        private readonly IRepository<ProfileAttachment> _profileAttachment;
        private readonly UserManager _userManager;
        private readonly IUserAppService _userAppService;
        public IAbpSession _AbpSession { get; set; }
        private IHostingEnvironment _hostingEnv;

        public AdditionalUserProfileAppService(
            IRepository<UserProfile> userProfile,
            UserManager userManager,
            IUserAppService userAppService,
            IHostingEnvironment hostingEnv,
            IRepository<ProfileAttachment> profileAttachment,
            IAbpSession AbpSession
            ) : base(userProfile)
        {
            _userProfile = userProfile;
            _userManager = userManager;
            _userAppService = userAppService;
            _hostingEnv = hostingEnv;
            _AbpSession = AbpSession;
            _profileAttachment = profileAttachment;
        }
        
        public async Task<AdditionalUserProfileDto> GetData(GetCurrentProfileDataDto input)
        {
            var profileData = await _userProfile.FirstOrDefaultAsync(
                p => p.UserId == input.UserId
            );

            return (ObjectMapper.Map<AdditionalUserProfileDto>(profileData));
        }

        public async Task CreateProfileWithAddition(CreateCombinedUserAndProfileDto input)
        {
            UserDto user = await _userAppService.Create(input.CreateUserDto);

            input.CreateAdditionalUserProfileDto.UserId = user.Id;

            await CreateAdditionalUserProfile(input.CreateAdditionalUserProfileDto);

         //  await _profileAttachment.InsertAsync(input.ProfileAttachment);
        }

        public async Task<CreateAdditionalUserProfileDto> CreateAdditionalUserProfile(CreateAdditionalUserProfileDto input)
        {
            var additionalUserProfile = ObjectMapper.Map<UserProfile>(input);
            await _userProfile.InsertOrUpdateAsync(additionalUserProfile);

            return (ObjectMapper.Map<CreateAdditionalUserProfileDto>(additionalUserProfile));
        }

        public async Task UpdateProfileWithAddition(CombinedUserProfileDto input)
        {
         
            input.AdditionalUserProfileDto.UserId = input.UserDto.Id;

            await _userAppService.Update(input.UserDto);

            await UpdateAdditionalUserProfile(input.AdditionalUserProfileDto);

        }

        public async Task<AdditionalUserProfileDto> UpdateAdditionalUserProfile(AdditionalUserProfileDto input)
        {
            var profileData = await _userProfile.FirstOrDefaultAsync(
                p => p.UserId == input.UserId
            );

            var id = profileData.Id;
            var usr = profileData.User;

            ObjectMapper.Map(input, profileData);

            profileData.Id = id;
            profileData.User = usr;
            await _userProfile.UpdateAsync(profileData);

            return (ObjectMapper.Map<AdditionalUserProfileDto>(profileData));
        }    

        public async Task DeleteProfileWithAddition(EntityDto<long> input)
        {
            await _userAppService.Delete(input);

            await DeleteAdditionalUserProfile(input);
        }

        public async Task DeleteAdditionalUserProfile(EntityDto<long> input)
        {
            await _userProfile.DeleteAsync(
                p => p.UserId == input.Id
            );
        }

        //Service To change Profile Picture.
        public async Task Upload(ProfilePicture input)
        {
            
            long size = 0;
            foreach (var file in input.F)
            {
                var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                var c = "/images/" + filename;
                filename = _hostingEnv.WebRootPath + $@"\images\{filename}";
                size += file.Length;

               /* var db = new ProfilePicture();
                db.ImagePath = c;
                db.ProfileId = (long)AbpSession.UserId;
                */
                ProfileAttachment update = _profileAttachment.FirstOrDefault(cc => cc.ProfileId == input.ProfileId);
                update.ImagePath = c;
                update.ProfileId = 10008;
                using (var stream = new FileStream(filename, FileMode.Create))
                {                  
                    await file.CopyToAsync(stream);
                    await _profileAttachment.UpdateAsync(update);
                   
                }
            }

        }
     

        public ProfileAttachment GetProfile(long id)
        {           
            return _profileAttachment.FirstOrDefault(i => i.ProfileId == id);
        }
    }

}
