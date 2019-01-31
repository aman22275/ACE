using System.Threading.Tasks;
using Abp.Application.Services;
using DF.ACE.Sessions.Dto;

namespace DF.ACE.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
