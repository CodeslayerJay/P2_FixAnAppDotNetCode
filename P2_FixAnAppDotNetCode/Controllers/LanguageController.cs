using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using P2_FixAnAppDotNetCode.Models.Services;
using P2_FixAnAppDotNetCode.Models.ViewModels;

namespace P2_FixAnAppDotNetCode.Controllers
{
    public class LanguageController : Controller
    {
        private ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeUILanguage(LanguageViewModel model, string returnUrl)
        {
            if (model.Language != null)
            {
                _languageService.ChangeUILanguage(HttpContext, model.Language);
            }

            return Redirect(returnUrl);
        }
    }
}
