using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using P2_FixAnAppDotNetCode.Models;
using P2_FixAnAppDotNetCode.Models.Services;
using System.Linq;

namespace P2_FixAnAppDotNetCode.Controllers
{
    public class OrderController : Controller
    {
        private ICart _cart;
        private IOrderService _orderService;
        private readonly IStringLocalizer<OrderController> _localizer;

        public OrderController(ICart pCart, IOrderService service, IStringLocalizer<OrderController> localizer)
        {
            _cart = pCart;
            _orderService = service;
            _localizer = localizer;
        }

        public ViewResult Index() => View(new Order());

        [HttpPost]
        public IActionResult Index(Order order)
        {
            if ((_cart as Cart).Lines.Count() == 0)
            {
                ModelState.AddModelError("", _localizer["CartEmpty"]);
            }
            if (ModelState.IsValid)
            {
                order.Lines = (_cart as Cart).Lines.ToArray();
                _orderService.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}
