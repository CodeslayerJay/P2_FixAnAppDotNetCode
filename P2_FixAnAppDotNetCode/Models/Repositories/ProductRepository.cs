﻿using System.Collections.Generic;
using System.Linq;

namespace P2_FixAnAppDotNetCode.Models.Repositories
{
    /// <summary>
    /// The class that manages product data
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private static List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();
            GenerateProductData();
        }

        /// <summary>
        /// Generate the default list of products
        /// </summary>
        private void GenerateProductData()
        {
            int id = 0;
            products.Add(new Product(++id, 10, 92.50, "Echo Dot", "(2nd Generation) - Black"));
            products.Add(new Product(++id, 20, 9.99, "Anker 3ft / 0.9m Nylon Braided", "Tangle-Free Micro USB Cable"));
            products.Add(new Product(++id, 30, 69.99, "JVC HAFX8R Headphone", "Riptidz, In-Ear"));
            products.Add(new Product(++id, 40, 32.50, "VTech CS6114 DECT 6.0", "Cordless Phone"));
            products.Add(new Product(++id, 50, 895.00, "NOKIA OEM BL-5J", "Cell Phone "));
        }

        /// <summary>
        /// Get all products from the inventory
        /// </summary>
        public Product[] GetAllProducts()
        {
            List<Product> list = products.Where(p => p.Stock > 0).OrderBy(p => p.Name).ToList();
            return list.ToArray();
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