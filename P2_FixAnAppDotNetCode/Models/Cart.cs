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

        // Create a private empty list
        private List<CartLine> _lines = new List<CartLine>();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {

            // Every time method is called a "new" empty List<CartLine>() is returned
            //return new List<CartLine>();

            // We want to persist the collection so we create a class member and initialize it to
            // new empty List<CartLine>();
            // Now when method is called we return the member collection
            return _lines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>
        public void AddItem(Product product, int quantity)
        {
            // Get product from _lines collection
            CartLine line = _lines.Find(l => l.Product.Id == product.Id);

            // If: line already has a product -> update the quantity
            // Else: Create a new item and store in the collection.
            if (line != null)
            {
                line.Quantity = line.Quantity + 1;
            }
            else
            {
                // Create an OrderLineID based on the current count of _lines
                int OrderId = 0;
                int count = _lines.Count;
                OrderId = count + 1;

                // Create new CartLine object passing in our arguments
                CartLine cartLine = new CartLine() { OrderLineID = OrderId, Product = product, Quantity = quantity };

                // Use LINQ to Add to list
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
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            
            
            return null;
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
