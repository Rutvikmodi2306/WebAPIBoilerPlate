using System.Threading.Tasks;
using WebAPIBoilerPlate.Models.TokenAuth;
using WebAPIBoilerPlate.Web.Controllers;
using Shouldly;
using Xunit;

namespace WebAPIBoilerPlate.Web.Tests.Controllers
{
    public class HomeController_Tests: WebAPIBoilerPlateWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}