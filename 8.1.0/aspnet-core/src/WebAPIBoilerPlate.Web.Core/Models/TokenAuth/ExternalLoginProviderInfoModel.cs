using Abp.AutoMapper;
using WebAPIBoilerPlate.Authentication.External;

namespace WebAPIBoilerPlate.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
