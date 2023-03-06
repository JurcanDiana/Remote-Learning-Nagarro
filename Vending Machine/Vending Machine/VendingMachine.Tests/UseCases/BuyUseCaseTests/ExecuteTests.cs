using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.Models;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.Repositories;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    public class ExecuteTests
    {
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IProductRepository> productRepository;
        private readonly Mock<IAuthenticationService> authenticationService;
        private readonly Mock<IPaymentUseCase> paymentUseCase;
        private readonly BuyUseCase buyUseCase;

        public ExecuteTests()
        {
            buyView = new Mock<IBuyView>();
            productRepository = new Mock<IProductRepository>();
            authenticationService = new Mock<IAuthenticationService>();
            paymentUseCase = new Mock<IPaymentUseCase>();

            buyUseCase = new BuyUseCase(buyView.Object, productRepository.Object, authenticationService.Object, paymentUseCase.Object);
        }

        [Fact]
        public void WhenInvalidProductIdIsEntered_ThrowsInvalidIdException()
        {
            buyView.Setup(x => x.RequestId()).Returns(-1);
            Assert.Throws<InvalidIdException>(() => buyUseCase.Execute());
        }

        [Fact]
        public void WhenInsufficientStock_ThrowsInsufficientStockException()
        {
            int productId = 1;
            buyView.Setup(x => x.RequestId()).Returns(productId);
            productRepository.Setup(x => x.GetById(productId)).Returns(new Product { Quantity = 0 });

            Assert.Throws<InsufficientStockException>(() => buyUseCase.Execute());
        }

        [Fact]
        public void HavingABuyUseCaseInstance_WhenExecuted_PaymentUseCaseIsExecutedWithCorrectAmount()
        {
            int productId = 1;
            Product product = new Product { Quantity = 1, Name = "Product 1", Price = 2.5f };
            buyView.Setup(x => x.RequestId()).Returns(productId);
            productRepository.Setup(x => x.GetById(productId)).Returns(product);

            buyUseCase.Execute();

            paymentUseCase.Verify(x => x.Execute(product.Price), Times.Once());
        }

        [Fact]
        public void HavingABuyUseCaseInstance_WhenExecuted_ProductRepositoryDecrementStockIsCalledOnce()
        {
            int productId = 1;
            Product product = new Product { Quantity = 1, Name = "Product 1", Price = 2.5f };
            buyView.Setup(x => x.RequestId()).Returns(productId);
            productRepository.Setup(x => x.GetById(productId)).Returns(product);

            buyUseCase.Execute();

            productRepository.Verify(x => x.DecrementStock(productId), Times.Once());
        }

        [Fact]
        public void HavingABuyUseCaseInstance_WhenExecuted_ViewDispenseProductIsCalledOnceWithCorrectProductName()
        {
            int productId = 1;
            Product product = new Product { Quantity = 1, Name = "Product 1", Price = 2.5f };
            buyView.Setup(x => x.RequestId()).Returns(productId);
            productRepository.Setup(x => x.GetById(productId)).Returns(product);

            buyUseCase.Execute();

            buyView.Verify(x => x.DispenseProduct(product.Name), Times.Once());
        }

    }
}
