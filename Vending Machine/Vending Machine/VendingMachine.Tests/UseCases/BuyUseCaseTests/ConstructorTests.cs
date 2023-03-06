using Moq;
using RemoteLearning.VendingMachine.UseCases;
using RemoteLearning.VendingMachine.Repositories;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.PresentationLayer;
using Xunit;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    public class ConstructorTests
    {
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IPaymentUseCase> paymentUseCase;

        public ConstructorTests()
        {
            buyView = new Mock<IBuyView>();
            productRepository = new Mock<IProductRepository>();
            authenticationService = new Mock<IAuthenticationService>();
            paymentUseCase = new Mock<IPaymentUseCase>();
        }

        [Fact]
        public void HavinNullBuyView_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new BuyUseCase(null, productRepository.Object, authenticationService.Object, paymentUseCase.Object);
            });
        }

        [Fact]
        public void HavingNullProductRepository_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new BuyUseCase(buyView.Object, null, authenticationService.Object, paymentUseCase.Object);
            });
        }

        [Fact]
        public void HavingNullAuthenticationService_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new BuyUseCase(buyView.Object, productRepository.Object, null, paymentUseCase.Object);
            });
        }

        [Fact]
        public void HavingNullPaymentUseCase_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new BuyUseCase(buyView.Object, productRepository.Object, authenticationService.Object, null);
            });
        }

        [Fact]
        public void WhenInitializingTheUseCase_NameIsCorrect()
        {
            BuyUseCase buyUseCase = new BuyUseCase(buyView.Object, productRepository.Object, authenticationService.Object, paymentUseCase.Object);
            Assert.Equal("buy product", buyUseCase.Name);
        }
    }
}
