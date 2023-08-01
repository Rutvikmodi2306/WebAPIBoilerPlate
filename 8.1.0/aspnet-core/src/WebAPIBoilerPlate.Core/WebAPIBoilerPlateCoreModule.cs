using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using WebAPIBoilerPlate.Authorization.Roles;
using WebAPIBoilerPlate.Authorization.Users;
using WebAPIBoilerPlate.Configuration;
using WebAPIBoilerPlate.Localization;
using WebAPIBoilerPlate.MultiTenancy;
using WebAPIBoilerPlate.Timing;

namespace WebAPIBoilerPlate
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class WebAPIBoilerPlateCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            WebAPIBoilerPlateLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = WebAPIBoilerPlateConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = WebAPIBoilerPlateConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = WebAPIBoilerPlateConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebAPIBoilerPlateCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
