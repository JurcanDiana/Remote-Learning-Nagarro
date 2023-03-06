namespace RemoteLearning.VendingMachine.PresentationLayer
{
    public interface IPaymentAlgorithm
    {
        public string Name { get; }
        public void Run(float price);
    }
}
