using Microsoft.AspNetCore.Mvc;
using P2_FixAnAppDotNetCode.Models;
using P2_FixAnAppDotNetCode.Models.Services;
using System.Linq;

namespace P2_FixAnAppDotNetCode.Controllers
{
    public class CartController : Controller
    {
        private ICart cart;
        private IProductService _productService;

        public CartController(ICart pCart, IProductService productService)
        {
            cart = pCart;
            _productService = productService;
        }

        public ViewResult Index()
        {
            return View(cart as Cart);
        }

        [HttpPost]
        public RedirectToActionResult AddToCart(int id)
        {
            Product product = _productService.GetProductById(id);

            if (product != null)
            {
                cart.AddItem(product, 1);
                
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
        }

        public RedirectToActionResult RemoveFromCart(int id)
        {
            Product product = _productService.GetAllProducts()
                .FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index");
        }
    }
}
