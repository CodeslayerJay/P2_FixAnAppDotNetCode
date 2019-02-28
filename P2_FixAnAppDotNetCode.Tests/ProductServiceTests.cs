using P2_FixAnAppDotNetCode.Models;
using P2_FixAnAppDotNetCode.Models.Repositories;
using P2_FixAnAppDotNetCode.Models.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace P2_FixAnAppDotNetCode.Tests
{
    /// <summary>
    /// The ProductService test class
    /// </summary>
    public class ProductServiceTests
    {

        [Fact]
        public void Product()
        {
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);

            var products = productService.GetAllProducts();

            Assert.IsType<List<Product>>(products);
        }

        [Fact]
        public void UpdateProductQuantities()
        {
            Cart cart = new Cart();
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);

            IEnumerable<Product> products = productService.GetAllProducts();
            cart.AddItem(products.Where(p => p.Id == 1).First(), 1);
            cart.AddItem(products.Where(p => p.Id == 3).First(), 2);
            cart.AddItem(products.Where(p => p.Id == 5).First(), 3);

            productService.UpdateProductQuantities(cart);

            Assert.Equal(19, products.Where(p => p.Id == 1).First().Stock);
            Assert.Equal(28, products.Where(p => p.Id == 3).First().Stock);
            Assert.Equal(37, products.Where(p => p.Id == 5).First().Stock);
        }

        [Fact]
        public void GetProductById()
        {
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);
            int id = 3;

            Product product = productService.GetProductById(id);

            Assert.Same("JVC HAFX8R Headphone", product.Name);
            Assert.Equal(69.99, product.Price);
        }
    }
}
