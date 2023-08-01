using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using WebAPIBoilerPlate.Authorization.Roles;
using WebAPIBoilerPlate.Authorization.Users;
using WebAPIBoilerPlate.MultiTenancy;

namespace WebAPIBoilerPlate.EntityFrameworkCore
{
    public class WebAPIBoilerPlateDbContext : AbpZeroDbContext<Tenant, Role, User, WebAPIBoilerPlateDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public WebAPIBoilerPlateDbContext(DbContextOptions<WebAPIBoilerPlateDbContext> options)
            : base(options)
        {
        }
    }
}
