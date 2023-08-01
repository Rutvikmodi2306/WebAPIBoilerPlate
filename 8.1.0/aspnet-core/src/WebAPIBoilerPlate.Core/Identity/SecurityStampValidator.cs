using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using WebAPIBoilerPlate.Authorization.Roles;
using WebAPIBoilerPlate.Authorization.Users;
using WebAPIBoilerPlate.MultiTenancy;
using Microsoft.Extensions.Logging;
using Abp.Domain.Uow;

namespace WebAPIBoilerPlate.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory,
            IUnitOfWorkManager unitOfWorkManager)
            : base(options, signInManager, systemClock, loggerFactory, unitOfWorkManager)
        {
        }
    }
}
