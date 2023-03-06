using System;
using System.Collections.Generic;
using RemoteLearning.VendingMachine.Payment;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView
    {
        public int RequestId()
        {
            Display("Enter product id: ", ConsoleColor.White);
            int productID = Convert.ToInt32(Console.ReadLine());
            return productID;
        }

        public void DispenseProduct(string productName)
        {
            string messageToDisplay = String.Format($"\nProduct {productName} has been dispensed.");
            Display(messageToDisplay, ConsoleColor.Green);
        }

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {
            Display("Choose payment method: \n", ConsoleColor.White);
            foreach (var paymentMethod in paymentMethods)
            {
                Display(paymentMethod.Id + ". " + paymentMethod.Name + "\n", ConsoleColor.White);
            }

            return int.Parse(Console.ReadLine());
        }
    }
}
