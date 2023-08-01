using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace WebAPIBoilerPlate.Controllers
{
    public abstract class WebAPIBoilerPlateControllerBase: AbpController
    {
        protected WebAPIBoilerPlateControllerBase()
        {
            LocalizationSourceName = WebAPIBoilerPlateConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
