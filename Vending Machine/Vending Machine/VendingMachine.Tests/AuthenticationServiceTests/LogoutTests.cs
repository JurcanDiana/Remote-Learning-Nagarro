using RemoteLearning.VendingMachine.Authentication;
using Xunit;

namespace VendingMachine.Tests.AuthenticationServiceTests
{
    public class LogoutTests
    {
        private const string correctPassword = "parola";

        [Fact]
        public void HavingAnAuthenticatedUser_WhenLogout_ThenUserIsNotAuthenticated()
        {
            var authenticationService = new AuthenticationService();
            authenticationService.Login(correctPassword);


            authenticationService.Logout();

            Assert.False(authenticationService.IsUserAuthenticated);

        }

        [Fact]
        public void HavingAnUnAuthenticatedUser_WhenLogout_ThenUserIsNotAuthenticated()
        {
            var authenticationService = new AuthenticationService();

            authenticationService.Logout();

            Assert.False(authenticationService.IsUserAuthenticated);
        }

    }
}
