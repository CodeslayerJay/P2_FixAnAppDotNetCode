using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.File.Protocol;

namespace P2_FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        // Set private field and initialize it
        private List<CartLine> _lines = new List<CartLine>();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {

            // Return CartLine collection _lines
            return _lines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>
        public void AddItem(Product product, int quantity)
        {
            // Find CartLine from _lines collection that matches Product.Id
            var line = _lines.Find(l => l.Product.Id == product.Id);
            
            // If line has product already then update the quantity
            if (line != null)
            {
                line.Quantity += quantity;
            }
            else
            {
                // Create a new item and store in the collection.
                var cartLine = new CartLine() {  Product = product, Quantity = quantity };

                // Add to the _lines collection
                _lines.Add(cartLine);

            }
            
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // Initialize
            double totalCartQuantity = 0;
            double totalCartValue = 0;

            // Loop through each item in collection
            foreach (var item in _lines)
            {
                // Add product quantity to total cart quantity
                totalCartQuantity = totalCartQuantity + item.Quantity;

                // Multiply quantity by price then add to totalCartValue
                totalCartValue = (item.Quantity * item.Product.Price) + totalCartValue;
            }

            // Return total value
            return totalCartValue;

        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // Initialize
            double totalCartQuantity = 0;
            double totalCartValue = 0;

            // Loop through each item in collection
            foreach (var item in _lines)
            {
                // Add product quantity to total cart quantity
                totalCartQuantity = totalCartQuantity + item.Quantity;

                // Multiply quantity by price then add to totalCartValue
                totalCartValue = (item.Quantity * item.Product.Price) + totalCartValue;
            }
            // Calculate average of totalCartValue and totalCartQuantity
            return totalCartValue / totalCartQuantity;


        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // Find Product in _lines by ID
            CartLine cartLine = GetCartLineList().Find(p => p.Product.Id == productId);

            // Return Product
            return cartLine.Product;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
