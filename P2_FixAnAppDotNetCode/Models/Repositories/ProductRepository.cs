using System.Collections.Generic;
using System.Linq;

namespace P2_FixAnAppDotNetCode.Models.Repositories
{
    /// <summary>
    /// The class that manages product data
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private static List<Product> products = new List<Product>();

        public ProductRepository()
        {
            if( !products.Any())
            {
                GenerateProductData();
            }
            //products = new List<Product>();
            
        }

        /// <summary>
        /// Generate the default list of products
        /// </summary>
        private void GenerateProductData()
        {
            int id = 0;
            products.Add(new Product(++id, 20, 92.50, "Echo Dot", "(2nd Generation) - Black"));
            products.Add(new Product(++id, 20, 9.99, "Anker 3ft / 0.9m Nylon Braided", "Tangle-Free Micro USB Cable"));
            products.Add(new Product(++id, 30, 69.99, "JVC HAFX8R Headphone", "Riptidz, In-Ear"));
            products.Add(new Product(++id, 40, 32.50, "VTech CS6114 DECT 6.0", "Cordless Phone"));
            products.Add(new Product(++id, 40, 895.00, "NOKIA OEM BL-5J", "Cell Phone "));
        }

        /// <summary>
        /// Get all products from the inventory
        /// </summary>
        public List<Product> GetAllProducts()
        {
            List<Product> list = products.Where(p => p.Stock > 0).OrderBy(p => p.Name).ToList();
            return list;
        }

        /// <summary>
        /// Get product by Id from the inventory
        /// </summary>
        public Product GetProductById(int id)
        {
            
            Product product = products.Where(p => p.Id == id).First();
            return product;

        }

        /// <summary>
        /// Update the stock of a product in the inventory by its id
        /// </summary>
        public void UpdateProductStocks(int productId, int quantityToRemove)
        {
            Product product = products.Where(p => p.Id == productId).First();
            product.Stock = product.Stock - quantityToRemove;

            if (product.Stock == 0)
                products.Remove(product);
        }
    }
}
