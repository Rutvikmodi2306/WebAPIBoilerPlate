using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebAPIBoilerPlate.Authorization;

namespace WebAPIBoilerPlate
{
    [DependsOn(
        typeof(WebAPIBoilerPlateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class WebAPIBoilerPlateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<WebAPIBoilerPlateAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(WebAPIBoilerPlateApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
