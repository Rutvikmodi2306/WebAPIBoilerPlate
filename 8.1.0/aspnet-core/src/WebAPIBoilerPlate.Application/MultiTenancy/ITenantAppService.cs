using Abp.Application.Services;
using WebAPIBoilerPlate.MultiTenancy.Dto;

namespace WebAPIBoilerPlate.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

