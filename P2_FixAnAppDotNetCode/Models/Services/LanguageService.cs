using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.ComponentModel.DataAnnotations;

namespace P2_FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Provides services method to manage the application language
    /// </summary>
    public class LanguageService : ILanguageService
    {
        /// <summary>
        /// Set the UI language
        /// </summary>
        public void ChangeUILanguage(HttpContext context, string language)
        {
            string culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }

        /// <summary>
        /// Set the culture
        /// </summary>
        public string SetCulture(string language)
        {
            string culture;
            
            // Default language is "en", french is "fr" and spanish is "es".
            // Check language being passed in and set to abbreviated string
            if (language == "French")
            {
                culture = "fr";
            }
            else if (language == "Spanish")
            {
                culture = "es";
            }
            else
            {
                culture = "en"; // Set as default
            }


            return culture;
        }

        /// <summary>
        /// Update the culture cookie
        /// </summary>
        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
        }
    }
}
