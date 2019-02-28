using Microsoft.AspNetCore.Mvc;
using P2_FixAnAppDotNetCode.Models;

namespace P2_FixAnAppDotNetCode.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart _cart;

        public CartSummaryViewComponent(ICart cart)
        {
            _cart = cart as Cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}
