using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LogoutUseCaseTests
{
    public class ExecuteTests
    {
        [Fact]
        public void HavingALogoutUseCaseInstance_WhenExecuted_ThenUserIsAuthenticated()
        {
            Mock<IAuthenticationService> authenticationService = new Mock<IAuthenticationService>();
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            logoutUseCase.Execute();

            authenticationService.Verify(x => x.Logout(), Times.Once);
        }
    }
}
