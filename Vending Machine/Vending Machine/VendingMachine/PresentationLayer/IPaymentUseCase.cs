namespace RemoteLearning.VendingMachine.PresentationLayer
{
    public interface IPaymentUseCase
    {
        void Execute(float price);
    }
}
