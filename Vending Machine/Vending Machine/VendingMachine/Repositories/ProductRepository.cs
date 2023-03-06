using System.Collections.Generic;
using RemoteLearning.VendingMachine.Models;

namespace RemoteLearning.VendingMachine.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product
            {
                ColumnId = 1,
                Name = "Chocolate",
                Price = 4.5f,
                Quantity = 0
            },
            new Product
            {
                ColumnId = 2,
                Name = "Cheese",
                Price = 20.5f,
                Quantity = 2
            },
            new Product
            {
                ColumnId = 3,
                Name = "Soda",
                Price = 3.75f,
                Quantity = 7
            },
            new Product
            {
                ColumnId = 4,
                Name = "Water",
                Price = 1.0f,
                Quantity = 10
            }
        };

        public IEnumerable<Product> GetAll()
        {
            return Products;
        }

        public Product GetById(int id) 
        {
            IEnumerable<Product> products = GetAll();
            foreach (Product product in products)
            {
                if (product.ColumnId == id) return product;
            }
            return null;
        }

        public void DecrementStock(int id)
        {
            foreach (Product product in Products)
            {
                if (product.ColumnId == id)
                    product.Quantity--;
            }
        }
    }
}
