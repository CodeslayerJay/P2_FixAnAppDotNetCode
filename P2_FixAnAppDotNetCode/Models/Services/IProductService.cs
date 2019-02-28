using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_FixAnAppDotNetCode.Models.Services
{
    public interface IProductService
    {
        Product[] GetAllProducts();
        Product GetProductById(int id);
        void UpdateProductQuantities(Cart cart);
    }
}
