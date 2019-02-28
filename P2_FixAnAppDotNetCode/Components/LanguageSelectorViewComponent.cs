using Microsoft.AspNetCore.Mvc;
using P2_FixAnAppDotNetCode.Models.Services;

namespace P2_FixAnAppDotNetCode.Components
{
    public class LanguageSelectorViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ILanguageService languageService)
        {
            return View(languageService);
        }
    }
}
