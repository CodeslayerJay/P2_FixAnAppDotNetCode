using P2_FixAnAppDotNetCode.Models.Services;
using System;
using Xunit;

namespace P2_FixAnAppDotNetCode.Tests
{
    /// <summary>
    /// The LanguageService class
    /// </summary>
    public class LanguageServiceTests
    {
        [Fact]
        public void SetCulture()
        {
            // Arrange
            ILanguageService languageService = new LanguageService();
            string language = "French";

            // Act
            string culture = languageService.SetCulture(language);

            // Assert
            Assert.Same("fr", culture);
        }
    }
}
