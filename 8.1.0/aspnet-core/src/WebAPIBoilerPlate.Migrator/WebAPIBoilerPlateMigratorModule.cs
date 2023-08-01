using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebAPIBoilerPlate.Configuration;
using WebAPIBoilerPlate.EntityFrameworkCore;
using WebAPIBoilerPlate.Migrator.DependencyInjection;

namespace WebAPIBoilerPlate.Migrator
{
    [DependsOn(typeof(WebAPIBoilerPlateEntityFrameworkModule))]
    public class WebAPIBoilerPlateMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public WebAPIBoilerPlateMigratorModule(WebAPIBoilerPlateEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(WebAPIBoilerPlateMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                WebAPIBoilerPlateConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebAPIBoilerPlateMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
