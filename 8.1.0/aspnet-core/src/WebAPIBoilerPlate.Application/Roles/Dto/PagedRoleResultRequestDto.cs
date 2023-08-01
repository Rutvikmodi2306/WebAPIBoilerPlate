using Abp.Application.Services.Dto;

namespace WebAPIBoilerPlate.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

