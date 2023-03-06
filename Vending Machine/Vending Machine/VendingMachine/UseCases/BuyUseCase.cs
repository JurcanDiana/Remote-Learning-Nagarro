using System;
using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.Models;
using RemoteLearning.VendingMachine.Repositories;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.PresentationLayer;

namespace RemoteLearning.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IBuyView buyView;
        private readonly IProductRepository productRepository;
        private readonly IAuthenticationService authenticationService;
        private readonly IPaymentUseCase paymentUseCase;

        public string Name => "buy product";
        public string Description => "Buy product.";
        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyUseCase(IBuyView buyView, IProductRepository productRepository, IAuthenticationService authenticationService, IPaymentUseCase paymentUseCase)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
    }

        public void Execute()
        {
            int productId = buyView.RequestId();

            if (productId < 0)
            {
                throw new InvalidIdException();
            }

            Product product = productRepository.GetById(productId);
            
            if (product == null)
            {
                throw new InvalidIdException();
            }

            if (product.Quantity == 0)
            {
                throw new InsufficientStockException();
            }

            paymentUseCase.Execute(product.Price);
            productRepository.DecrementStock(productId);
            buyView.DispenseProduct(product.Name);
        }
    }
}
