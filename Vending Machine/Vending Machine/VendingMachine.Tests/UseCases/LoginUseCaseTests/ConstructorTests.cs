using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;   
using Xunit;

namespace VendingMachine.Tests.UseCases.LoginUseCaseTests
{
    public class ConstructorTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<ILoginView> loginView;

        public ConstructorTests()
        {
            authenticationService = new Mock<IAuthenticationService>();
            loginView = new Mock<ILoginView>();
        }

        [Fact]
        public void HavingNullAuthenticationService_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
           {
               new LoginUseCase(null, loginView.Object);
           });
        }

        [Fact]
        public void HavingNullLoginView_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new LoginUseCase(authenticationService.Object, null);
            });
        }

        [Fact]
        public void WhenInitializingTheUseCase_NameIsCorrect()
        {
            LoginUseCase loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);

            Assert.Equal("login", loginUseCase.Name);
        }

    }
}
