using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_FixAnAppDotNetCode.Models.Services
{
    public interface ILanguageService
    {
        void ChangeUILanguage(HttpContext context, string language);
        string SetCulture(string language);
        void UpdateCultureCookie(HttpContext context, string culture);
    }
}
