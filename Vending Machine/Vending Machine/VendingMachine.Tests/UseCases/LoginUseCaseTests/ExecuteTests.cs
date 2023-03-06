using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LoginUseCaseTests
{
    public class ExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<ILoginView> loginView;
        private readonly LoginUseCase loginUsecase;

        public ExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            loginView = new Mock<ILoginView>();

            loginUsecase = new LoginUseCase(authenticationService.Object, loginView.Object);
        }

        [Fact]
        public void HavingALoginUseCaseInstance_WhenExecuted_TheUserIsAskedToInputPassword()
        {
            loginUsecase.Execute();

            loginView.Verify(x => x.AskForPassword(), Times.Once);
        }

        [Fact]
        public void HavingALoginUseCaseInstance_WhenExecuted_TheUserIsAuthenticated()
        {
            loginView.Setup(x => x.AskForPassword()).Returns("parola");

            loginUsecase.Execute();

            authenticationService.Verify(x => x.Login("parola"), Times.Once);
        }

    }
}
