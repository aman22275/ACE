using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DF.ACE.Configuration;

namespace DF.ACE.Web.Host.Startup
{
    [DependsOn(
       typeof(ACEWebCoreModule))]
    public class ACEWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ACEWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ACEWebHostModule).GetAssembly());
        }
    }
}
