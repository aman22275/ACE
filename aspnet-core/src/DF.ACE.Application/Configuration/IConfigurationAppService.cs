using System.Threading.Tasks;
using DF.ACE.Configuration.Dto;

namespace DF.ACE.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
