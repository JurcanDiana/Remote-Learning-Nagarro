using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.Repositories;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    public class CanExecuteTests
    {
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IPaymentUseCase> paymentUseCase;

        public CanExecuteTests()
        {
            buyView = new Mock<IBuyView>();
            productRepository = new Mock<IProductRepository>();
            authenticationService = new Mock<IAuthenticationService>();
            paymentUseCase = new Mock<IPaymentUseCase>();
        }

        [Fact]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            authenticationService.Setup(x => x.IsUserAuthenticated).Returns(false);
            var buyUseCase = new BuyUseCase(buyView.Object, productRepository.Object, authenticationService.Object, paymentUseCase.Object);
            Assert.True(buyUseCase.CanExecute);
        }

        [Fact]
        public void HavingAdminLoggedIn_CanExecuteIsFalse()
        {
            authenticationService.Setup(x => x.IsUserAuthenticated).Returns(true);
            var buyUseCase = new BuyUseCase(buyView.Object, productRepository.Object, authenticationService.Object, paymentUseCase.Object);
            Assert.False(buyUseCase.CanExecute);
        }
    }
}
