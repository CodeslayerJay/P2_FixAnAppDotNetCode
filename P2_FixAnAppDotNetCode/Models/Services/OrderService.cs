using P2_FixAnAppDotNetCode.Models.Repositories;
using System;

namespace P2_FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Provides services to manage an order
    /// </summary>
    public class OrderService : IOrderService
    {
        ICart _cart;
        IOrderRepository _repository;
        IProductService _productService;

        public OrderService(ICart cart, IOrderRepository orderRepo, IProductService productService)
        {
            _repository = orderRepo;
            _cart = cart;
            _productService = productService;
        }

        /// <summary>
        /// Saves an order
        /// </summary>
        public void SaveOrder(Order order)
        {
            order.Date = DateTime.Now;
            _repository.Save(order);
            UpdateInventory();
        }

        /// <summary>
        /// Update the product quantities inventory and clears the cart
        /// </summary>
        private void UpdateInventory()
        {
            _productService.UpdateProductQuantities(_cart as Cart);
            _cart.Clear();
        }
    }
}
