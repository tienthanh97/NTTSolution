
namespace NTT.ScrapingLib.ConfigHandler.Factory
{
    using NTT.ScrapingLib.Model.ScrapingConfig.Enums;
    using NTT.ScrapingLib.ScrapingHelper;

    public static class ScrapingHelperFactory
    {
        /// <summary>
        /// Gets the scraping helper.
        /// </summary>
        /// <param name="scrapType">Type of the scrap.</param>
        /// <param name="document">The document.</param>
        /// <returns>IScrapingHelper</returns>
        public static IScrapingHelper GetScrapingHelper(ScrapingType scrapType,string document)
        {
            IScrapingHelper result;

            switch (scrapType)
            {
                case ScrapingType.HTMLValue:
                    result = new HTMLValueHelper(document);
                    break;
                case ScrapingType.HTMLDoc:
                    result = new HTMLDocHelper(document);
                    break;
                case ScrapingType.JsonDoc:
                    result = new JsonDocHelper(document);
                    break;
                case ScrapingType.ApiUrl:
                    result = new ApiUrlHelper(document);
                    break;
                case ScrapingType.WebUrl:
                    result = new WebUrlHelper(document);
                    break;
                case ScrapingType.Text:
                    result = new TextHelper(document);
                    break;
                case ScrapingType.HTMLAttribute:
                    result = new HTMLAttributeHelper(document);
                    break;
                case ScrapingType.JsonVlue:
                    result = new JsonValueHelper(document);
                    break;
                //case ScrapingType.WebDriver:
                // //   result = new WebDriverHelper(document);
                //    break;
                //case ScrapingType.Header:
                //   // result = new HeaderHelper(document);
                //    break;
                default:
                    result = new ApiUrlHelper(document);
                    break;
            }
            return result;
        }
    }
}
