using Moq;
using RemoteLearning.VendingMachine.UseCases;
using RemoteLearning.VendingMachine.Repositories;
using RemoteLearning.VendingMachine.PresentationLayer;
using Xunit;

namespace VendingMachine.Tests.UseCases.LookUseCaseTests
{
    public class ConstructorTests
    {
        private readonly Mock<IShelfView> shelfView;
        private readonly Mock<IProductRepository> productRepository;

        public ConstructorTests()
        {
            shelfView = new Mock<IShelfView>();
            productRepository = new Mock<IProductRepository>();
        }

        [Fact]
        public void HavingNullShelfView_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new LookUseCase(null, productRepository.Object);
            });
        }

        [Fact]
        public void HavingNullProductRepository_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new LookUseCase(shelfView.Object, null);
            });
        }

        [Fact]
        public void WhenInitializingTheUseCase_NameIsCorrect()
        {
            LookUseCase lookUseCase = new LookUseCase(shelfView.Object, productRepository.Object);
            Assert.Equal("look at the products", lookUseCase.Name);
        }
    }
}
