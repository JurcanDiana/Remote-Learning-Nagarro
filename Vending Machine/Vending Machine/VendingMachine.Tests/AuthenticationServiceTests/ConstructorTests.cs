using Xunit;
using RemoteLearning.VendingMachine.Authentication;

namespace Nagarro.VendingMachine.Tests.AuthenticationServiceTests
{
    public class ConstructorTests
    {
        [Fact]
        public void HavingAuthenticationServiceInstance_ThenUserIsNotAuthenticated()
        {
            AuthenticationService authenticationService = new AuthenticationService();

            Assert.False(authenticationService.IsUserAuthenticated);
        }
    }
}
