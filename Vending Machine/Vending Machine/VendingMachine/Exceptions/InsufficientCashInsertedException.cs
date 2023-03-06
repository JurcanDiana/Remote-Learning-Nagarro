using System;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class InsufficientCashInsertedException : Exception
    {
        private const string DefaultMessage = "Insufficient cash inserted!";
        public InsufficientCashInsertedException()
            : base(DefaultMessage)
        {
        }
    }
}
