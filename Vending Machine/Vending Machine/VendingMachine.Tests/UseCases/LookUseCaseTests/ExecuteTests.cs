using Moq;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.Repositories;
using RemoteLearning.VendingMachine.UseCases;
using RemoteLearning.VendingMachine.Models;
using Xunit;

namespace VendingMachine.Tests.UseCases.LookUseCaseTests
{
    public class ExecuteTests
    {
        private readonly Mock<IProductRepository> productRepository; 
        private readonly Mock<IShelfView> shelfView;
        private readonly LookUseCase lookUsecase;

        public ExecuteTests() 
        {
            shelfView = new Mock<IShelfView>();
            productRepository = new Mock<IProductRepository>();

            lookUsecase = new LookUseCase(shelfView.Object, productRepository.Object);
        }

        [Fact]
        public void WhenExecutingTheUseCase_DisplayProductsMethodIsCalled()
        {
            lookUsecase.Execute();

            shelfView.Verify(x => x.DisplayProducts(It.IsAny<Product[]>()), Times.Once);
        }

        [Fact]
        public void WhenExecutingTheUseCase_GetAllMethodIsCalled()
        {
            lookUsecase.Execute();

            productRepository.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
