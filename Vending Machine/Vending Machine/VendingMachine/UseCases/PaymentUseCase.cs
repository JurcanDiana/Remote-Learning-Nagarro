using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.Payment;
using RemoteLearning.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteLearning.VendingMachine.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private readonly List<IPaymentAlgorithm> paymentAlgorithms;
        private readonly IBuyView buyView;
        List<PaymentMethod> paymentMethods;

        public PaymentUseCase(List<IPaymentAlgorithm> paymentAlgorithms, IBuyView buyView)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentAlgorithms = paymentAlgorithms ?? throw new ArgumentNullException(nameof(paymentAlgorithms));
            paymentMethods = new List<PaymentMethod>();
            InitializePaymentMethods();
        }
        public void Execute(float price)
        {
            IPaymentAlgorithm paymentAlgorithm = ChoosePaymentAlgorithm(paymentAlgorithms);
            paymentAlgorithm.Run(price);
        }

        private void InitializePaymentMethods()
        {
            int index = 1;

            foreach (var algorithm in paymentAlgorithms)
            {
                PaymentMethod paymentMethod = new PaymentMethod { Id = index, Name = algorithm.Name };
                paymentMethods.Add(paymentMethod);
                index++;
            }
        }

        private IPaymentAlgorithm ChoosePaymentAlgorithm(List<IPaymentAlgorithm> paymentAlgorithms)
        {
            int paymentMethodId = buyView.AskForPaymentMethod(paymentMethods);

            if (paymentMethods.FirstOrDefault(x => x.Id == paymentMethodId) == null)
            {
                throw new CancelException();
            }

            PaymentMethod chosenPaymentMethod = paymentMethods.FirstOrDefault(x => x.Id == paymentMethodId);

            if (paymentAlgorithms.FirstOrDefault(x => x.Name == chosenPaymentMethod.Name) == null)
            {
                throw new CancelException();
            }

            IPaymentAlgorithm chosenPaymentAlgorithm = paymentAlgorithms.FirstOrDefault(x => x.Name == chosenPaymentMethod.Name);

            return chosenPaymentAlgorithm;
        }

    }
}
