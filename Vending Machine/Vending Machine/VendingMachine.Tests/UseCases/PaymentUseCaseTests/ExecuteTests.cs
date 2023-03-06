using Moq;
using RemoteLearning.VendingMachine.PresentationLayer;
using Xunit;
using RemoteLearning.VendingMachine.UseCases;
using RemoteLearning.VendingMachine.Payment;

namespace VendingMachine.Tests.UseCases.PaymentUseCaseTests
{
    public class ExecuteTests
    {
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<IPaymentAlgorithm> cashPaymentAlgorithm;
        private readonly Mock<IPaymentAlgorithm> cardPaymentAlgorithm;
        private readonly PaymentUseCase paymentUseCase;

        public ExecuteTests()
        {
            buyView = new Mock<IBuyView>();
            cashPaymentAlgorithm = new Mock<IPaymentAlgorithm>();
            cardPaymentAlgorithm = new Mock<IPaymentAlgorithm>();

            paymentUseCase = new PaymentUseCase(
                new List<IPaymentAlgorithm>
                {
                    cashPaymentAlgorithm.Object,
                    cardPaymentAlgorithm.Object
                },
                buyView.Object);
        }


        [Fact]
        public void WhenPaymentMethodIsCash_CashPaymentAlgorithmIsExecutedWithCorrectAmount()
        {
            float price = 1.5f;
            buyView.Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>())).Returns(1);

            paymentUseCase.Execute(price);

            cashPaymentAlgorithm.Verify(x => x.Run(price), Times.Once());
        }

        [Fact]
        public void WhenPaymentMethodIsCard_CardPaymentAlgorithmIsExecutedWithCorrectAmount()
        {
            float price = 1.5f;
            buyView.Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>())).Returns(1);

            paymentUseCase.Execute(price);

            cardPaymentAlgorithm.Verify(x => x.Run(price), Times.Once());
        }

        [Fact]
        public void WhenPaymentMethodIsInvalid_NoPaymentAlgorithmIsExecuted()
        {
            float price = 1.5f;
            buyView.Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>())).Returns(0);

            paymentUseCase.Execute(price);

            cashPaymentAlgorithm.Verify(x => x.Run(It.IsAny<float>()), Times.Never);
            cardPaymentAlgorithm.Verify(x => x.Run(It.IsAny<float>()), Times.Never);
        }

        [Fact]
        public void WhenPaymentMethodIsEmpty_NoPaymentAlgorithmIsExecuted()
        {
            float price = 1.5f;
            buyView.Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>())).Returns(-1);

            paymentUseCase.Execute(price);

            cashPaymentAlgorithm.Verify(x => x.Run(It.IsAny<float>()), Times.Never);
            cardPaymentAlgorithm.Verify(x => x.Run(It.IsAny<float>()), Times.Never);
        }
    }
}
