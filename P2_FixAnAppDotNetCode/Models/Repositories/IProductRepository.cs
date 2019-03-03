using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts(); // Set to list
        Product GetProductById(int id); // Added member definition
        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
