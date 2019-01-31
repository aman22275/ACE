using Abp.Application.Services;
using DF.ACE.AdditionalUserProfile.Dto;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using DF.ACE.Common.Attachment;

namespace DF.ACE.AdditionalUserProfile
{
    public interface IAdditionalUserProfileAppService : IApplicationService
    {
        Task<AdditionalUserProfileDto> GetData(GetCurrentProfileDataDto input);

        Task<CreateAdditionalUserProfileDto> CreateAdditionalUserProfile(CreateAdditionalUserProfileDto input);

        Task<AdditionalUserProfileDto> UpdateAdditionalUserProfile(AdditionalUserProfileDto input);

        Task DeleteAdditionalUserProfile(EntityDto<long> input);

        Task Upload(ProfilePicture input);

        ProfileAttachment GetProfile(long id);
    }

}
