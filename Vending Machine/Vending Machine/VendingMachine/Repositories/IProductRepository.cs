using RemoteLearning.VendingMachine.Models;
using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.Repositories
{
    internal interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public void DecrementStock(int id);
    }
}
