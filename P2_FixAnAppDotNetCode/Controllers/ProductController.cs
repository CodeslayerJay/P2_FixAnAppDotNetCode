using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using P2_FixAnAppDotNetCode.Models;
using P2_FixAnAppDotNetCode.Models.Services;
using System.Collections.Generic;
using System.Threading;

namespace P2_FixAnAppDotNetCode.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ILanguageService _languageService;

        public ProductController(IProductService productService, ILanguageService languageService)
        {
            _productService = productService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            List<Product> products = _productService.GetAllProducts();
            return View(products);
        }
    }
}