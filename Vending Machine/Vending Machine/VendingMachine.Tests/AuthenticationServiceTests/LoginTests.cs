using RemoteLearning.VendingMachine.Authentication;
using Xunit;

namespace VendingMachine.Tests.AuthenticationServiceTests
{
    public class LoginTests
    {
        private const string correctPassword = "parola";

        [Fact]
        public void HavingAnAuthenticationService_WhenLoginWithCorrectPassword_ThenUserIsAuthenticated()
        {
            var authenticationService = new AuthenticationService();

            authenticationService.Login(correctPassword);

        }

        [Fact]
        public void HavingAnAuthenticationService_WhenLoginWithInCorrectPassword_ThenThrowsException()
        {
            var authenticationService = new AuthenticationService();

            Assert.Throws<InvalidPasswordException>(() =>
            {
                authenticationService.Login("incorrect-password");
            });
        }


    }
}
