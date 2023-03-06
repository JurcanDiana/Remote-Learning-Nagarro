using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LogoutUseCaseTests
{
  
    public class CanExecuteTests
    {
        private Mock<IAuthenticationService> authenticationService;

        public CanExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
        }

        [Fact]
        public void HavingNoAdminLoggedIn_CanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            Assert.False(logoutUseCase.CanExecute);
        }

        [Fact]
        public void HavingAdminLoggedIn_CanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            Assert.True(logoutUseCase.CanExecute);
        }
    }
}
