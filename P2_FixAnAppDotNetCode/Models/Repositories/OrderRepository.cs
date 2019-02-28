using System.Collections.Generic;

namespace P2_FixAnAppDotNetCode.Models.Repositories
{
    /// <summary>
    /// The class that manages order data
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private List<Order> orders;

        public OrderRepository()
        {
            orders = new List<Order>();
        }

        /// <summary>
        /// Saves an order
        /// </summary>
        public void Save(Order order)
        {
            orders.Add(order);
        }
    }
}