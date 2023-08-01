using System.Threading.Tasks;
using WebAPIBoilerPlate.Configuration.Dto;

namespace WebAPIBoilerPlate.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
