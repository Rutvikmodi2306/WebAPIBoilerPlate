using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebAPIBoilerPlate.Configuration;

namespace WebAPIBoilerPlate.Web.Host.Startup
{
    [DependsOn(
       typeof(WebAPIBoilerPlateWebCoreModule))]
    public class WebAPIBoilerPlateWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public WebAPIBoilerPlateWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebAPIBoilerPlateWebHostModule).GetAssembly());
        }
    }
}
