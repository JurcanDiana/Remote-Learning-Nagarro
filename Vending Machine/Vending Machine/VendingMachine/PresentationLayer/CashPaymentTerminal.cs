using System;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase
    {
        public CashPaymentTerminal() { }
        public float askForMoney(float price)
        {
            Display("\nPayment: " + price + " lei.", ConsoleColor.White);
            Display("\nIntroduce cash: ", ConsoleColor.White);

            float paymentInput = Convert.ToSingle(Console.ReadLine());
            return paymentInput;
        }

        public void GiveBackChange(float change)
        {
            int[] denominations = { 50000, 20000, 10000, 5000, 1000, 500, 100, 50, 10, 5, 1 };
            int remainingAmount = (int)Math.Round(change * 100);

            Display("\nPayment has been successful.\n", ConsoleColor.Magenta);
            Display("\nYour change: ", ConsoleColor.White);

            for (int i = 0; i < denominations.Length; i++)
            {
                int count = remainingAmount / denominations[i];
                remainingAmount %= denominations[i];

                if (count > 0)
                {
                    if (denominations[i] > 50)
                    {
                        Display($"\n{count} x {denominations[i] / 100.0} lei", ConsoleColor.White);
                    }
                    else
                    {
                        Display($"\n{count} x {denominations[i]} bani", ConsoleColor.White);
                    }
                }
            }
        }

    }
}
