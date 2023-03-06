using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.Repositories;
using System;

namespace RemoteLearning.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private readonly IShelfView shelfView;
        private readonly IProductRepository productRepository;

        public string Name => "look at the products";

        public string Description => "Display list of products available.";

        public bool CanExecute => true;

        public LookUseCase(IShelfView shelfView, IProductRepository productRepository)
        {
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void Execute()
        {
            shelfView.DisplayProducts(productRepository.GetAll());
        }
    }
}
