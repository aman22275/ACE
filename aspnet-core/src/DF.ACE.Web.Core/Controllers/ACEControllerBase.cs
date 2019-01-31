using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace DF.ACE.Controllers
{
    public abstract class ACEControllerBase: AbpController
    {
        protected ACEControllerBase()
        {
            LocalizationSourceName = ACEConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
