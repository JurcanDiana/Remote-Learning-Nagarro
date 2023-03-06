using System;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class CancelException : Exception
    {
        private const string DefaultMessage = "Cancel buy process";
        public CancelException()
            : base(DefaultMessage)
        {
        }
    }
}
