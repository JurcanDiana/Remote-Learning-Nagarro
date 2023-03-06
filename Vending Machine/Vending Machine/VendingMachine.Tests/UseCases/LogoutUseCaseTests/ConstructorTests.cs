using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LogoutUseCaseTests
{
    public class ConstructorTests
    {
        [Fact]
        public void HavingANullAuthenticationService_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new LogoutUseCase(null);
            });
        }
    }
}
