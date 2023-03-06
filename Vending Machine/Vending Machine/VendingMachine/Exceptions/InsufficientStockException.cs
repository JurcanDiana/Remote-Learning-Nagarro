using System;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class InsufficientStockException : Exception
    {
        private const string DefaultMessage = "Insufficient stock";
        public InsufficientStockException()
            : base(DefaultMessage)
        {
        }
    }
}
