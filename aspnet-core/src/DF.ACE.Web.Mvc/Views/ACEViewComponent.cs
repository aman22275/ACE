using Abp.AspNetCore.Mvc.ViewComponents;

namespace DF.ACE.Web.Views
{
    public abstract class ACEViewComponent : AbpViewComponent
    {
        protected ACEViewComponent()
        {
            LocalizationSourceName = ACEConsts.LocalizationSourceName;
        }
    }
}
