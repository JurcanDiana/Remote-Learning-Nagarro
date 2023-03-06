using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LoginUseCaseTests
{
    public class CanExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<ILoginView> loginView;

        public CanExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            loginView = new Mock<ILoginView>();
        }

        [Fact]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            authenticationService.Setup(x => x.IsUserAuthenticated).Returns(false);
            var loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);
            Assert.True(loginUseCase.CanExecute);
        }

        [Fact]
        public void HavingAdminLoggedIn_CanExecuteIsFalse()
        {
            authenticationService.Setup(x => x.IsUserAuthenticated).Returns(true);
            var loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);
            Assert.False(loginUseCase.CanExecute);
        }

    }
}
