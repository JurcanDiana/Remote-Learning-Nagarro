namespace RemoteLearning.TheUniverse.Infrastructure
{
    public interface IRequestHandler<TResponse, TRequest>
    {
        TResponse Execute(TRequest request);
    }
}