using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using WebAPIBoilerPlate.EntityFrameworkCore.Seed;

namespace WebAPIBoilerPlate.EntityFrameworkCore
{
    [DependsOn(
        typeof(WebAPIBoilerPlateCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class WebAPIBoilerPlateEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<WebAPIBoilerPlateDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        WebAPIBoilerPlateDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        WebAPIBoilerPlateDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebAPIBoilerPlateEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
