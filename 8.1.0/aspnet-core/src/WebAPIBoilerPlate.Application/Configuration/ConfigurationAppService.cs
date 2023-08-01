using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using WebAPIBoilerPlate.Configuration.Dto;

namespace WebAPIBoilerPlate.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : WebAPIBoilerPlateAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
