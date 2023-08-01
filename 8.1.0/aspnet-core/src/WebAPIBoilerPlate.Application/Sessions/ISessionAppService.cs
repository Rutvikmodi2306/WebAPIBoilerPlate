using System.Threading.Tasks;
using Abp.Application.Services;
using WebAPIBoilerPlate.Sessions.Dto;

namespace WebAPIBoilerPlate.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
