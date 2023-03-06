using System;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class InvalidCardNumberException : Exception
    {
        private const string DefaultMessage = "Invalid card number";
        public InvalidCardNumberException()
            : base(DefaultMessage)
        {
        }
    }
}
