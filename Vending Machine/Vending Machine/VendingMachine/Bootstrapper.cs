using System.Collections.Generic;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.Payment;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.Repositories;
using RemoteLearning.VendingMachine.UseCases;

namespace RemoteLearning.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            MainView mainView = new MainView();
            LoginView loginView = new LoginView();
            ShelfView shelfView = new ShelfView();
            BuyView buyView = new BuyView();

            CardPaymentTerminal cardPaymentTerminal = new CardPaymentTerminal();
            CashPaymentTerminal cashPaymentTerminal = new CashPaymentTerminal();

            List<IPaymentAlgorithm> paymentAlgorithms = new List<IPaymentAlgorithm>
            {
                new CashPayment(cashPaymentTerminal),
                new CardPayment(cardPaymentTerminal)
            };

            ProductRepository productRepository = new ProductRepository();
            AuthenticationService authenticationService = new AuthenticationService();
            PaymentUseCase paymentUseCase = new PaymentUseCase(paymentAlgorithms, buyView);

            List<IUseCase> useCases = new List<IUseCase>
            {
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                new LookUseCase(shelfView, productRepository),
                new BuyUseCase(buyView, productRepository, authenticationService, paymentUseCase)
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}