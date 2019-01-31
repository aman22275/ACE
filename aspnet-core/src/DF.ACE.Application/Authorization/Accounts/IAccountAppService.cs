using System.Threading.Tasks;
using Abp.Application.Services;
using DF.ACE.Authorization.Accounts.Dto;

namespace DF.ACE.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
