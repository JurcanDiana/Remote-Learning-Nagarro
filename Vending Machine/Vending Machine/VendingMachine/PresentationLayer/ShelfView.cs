using RemoteLearning.VendingMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal class ShelfView : DisplayBase, IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            if (products.Any())
            {
                Display("\nList of products on the shelf: \n", ConsoleColor.Cyan);
                foreach (Product product in products)
                {
                    Console.Write($"Product {product.ColumnId}. {product.Name}\n");
                }
            }
            else
            {
                Display("\nList of products is empty.", ConsoleColor.Red);
            }
        }
    }
}
