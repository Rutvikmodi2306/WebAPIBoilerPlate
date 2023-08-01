using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebAPIBoilerPlate.EntityFrameworkCore;
using WebAPIBoilerPlate.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace WebAPIBoilerPlate.Web.Tests
{
    [DependsOn(
        typeof(WebAPIBoilerPlateWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class WebAPIBoilerPlateWebTestModule : AbpModule
    {
        public WebAPIBoilerPlateWebTestModule(WebAPIBoilerPlateEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebAPIBoilerPlateWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(WebAPIBoilerPlateWebMvcModule).Assembly);
        }
    }
}