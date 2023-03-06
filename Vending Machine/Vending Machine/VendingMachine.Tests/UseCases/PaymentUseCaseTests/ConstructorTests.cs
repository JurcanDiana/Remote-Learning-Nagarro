using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.Payment;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.PaymentUseCaseTests
{
    public class ConstructorTests
    {
        private readonly Mock<IBuyView> buyView;
        private readonly List<IPaymentAlgorithm> paymentAlgorithms;

        public ConstructorTests()
        {
            buyView = new Mock<IBuyView>();
            paymentAlgorithms = new List<IPaymentAlgorithm>();
        }

        [Fact]
        public void HavingNullBuyView_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new PaymentUseCase(paymentAlgorithms, null);
            });
        }

        [Fact]
        public void HavingNullPaymentAlgorithms_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new PaymentUseCase(null, buyView.Object);
            });
        }
    }
}
