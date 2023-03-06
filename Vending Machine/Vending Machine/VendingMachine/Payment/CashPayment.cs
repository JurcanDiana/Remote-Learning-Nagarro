using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.PresentationLayer;

namespace RemoteLearning.VendingMachine.Payment
{
    internal class CashPayment : IPaymentAlgorithm
    {
        public string Name => "Cash";
        private readonly CashPaymentTerminal cashPaymentTerminal;

        public CashPayment(CashPaymentTerminal cashPaymentTerminal)
        {
            this.cashPaymentTerminal = cashPaymentTerminal;
        }

        public void Run(float price)
        {
            float requestedPayment = cashPaymentTerminal.askForMoney(price);

            if (requestedPayment < price)
            {
                throw new InsufficientCashInsertedException();
            }

            cashPaymentTerminal.GiveBackChange(requestedPayment - price);
        }
    }

}
