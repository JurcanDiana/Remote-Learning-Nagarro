using System.Collections.Generic;
using RemoteLearning.VendingMachine.Payment;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface IBuyView
    {
        public int RequestId();
        public void DispenseProduct(string productName);

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}
