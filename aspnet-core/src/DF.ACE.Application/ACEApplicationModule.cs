using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DF.ACE.Authorization;

namespace DF.ACE
{
    [DependsOn(
        typeof(ACECoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ACEApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ACEAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ACEApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
