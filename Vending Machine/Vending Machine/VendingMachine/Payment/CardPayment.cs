using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.PresentationLayer;
using System;

namespace RemoteLearning.VendingMachine.Payment
{
    internal class CardPayment : DisplayBase, IPaymentAlgorithm
    {
        public string Name => "Card";
        private readonly CardPaymentTerminal cardPaymentTerminal;

        public CardPayment(CardPaymentTerminal cardPaymentTerminal)
        {
            this.cardPaymentTerminal = cardPaymentTerminal;
        }

        public void Run(float price)
        {
            if (!IsValidCardNumber(cardPaymentTerminal.AskForCardNumber(price)))
            {
                throw new InvalidCardNumberException();
            }
            Display("Payment has been successful.\n", ConsoleColor.Magenta);
        }

        private bool IsValidCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
            {
                return false;
            }

            int sum = 0;
            int parity = cardNumber.Length % 2;

            for (int i = 0; i < cardNumber.Length; i++)
            {
                int digit = cardNumber[i] - '0';

                if (i % 2 != parity)
                {
                    sum += digit;
                }
                else if (digit > 4)
                {
                    sum += 2 * digit - 9;
                }
                else
                {
                    sum += 2 * digit;
                }
            }

            return sum % 10 == 0;
        }
    }
}
