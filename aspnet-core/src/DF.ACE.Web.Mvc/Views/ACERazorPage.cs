using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace DF.ACE.Web.Views
{
    public abstract class ACERazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ACERazorPage()
        {
            LocalizationSourceName = ACEConsts.LocalizationSourceName;
        }
    }
}
