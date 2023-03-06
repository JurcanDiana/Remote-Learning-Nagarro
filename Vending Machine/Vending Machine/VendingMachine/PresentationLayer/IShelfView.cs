using RemoteLearning.VendingMachine.Models;
using System.Collections.Generic;

namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products) { }
    }
}
