using System;

namespace RemoteLearning.VendingMachine.Exceptions
{
    internal class InvalidIdException: Exception
    {
        private const string DefaultMessage = "Invalid ID";
        public InvalidIdException()
            : base(DefaultMessage) 
        { 
        }
    }
}
