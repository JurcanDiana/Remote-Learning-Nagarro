using System;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal : DisplayBase
    {
        public CardPaymentTerminal() { }
        public string AskForCardNumber(float price)
        {
            Display("\nPrice: " + price + " lei.", ConsoleColor.White);
            Display("\nIntroduce card number:", ConsoleColor.White);
            string cardNumberInput = Console.ReadLine();
            return cardNumberInput;
        }
    }
}
