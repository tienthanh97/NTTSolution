
namespace NTT.ScrapingLib.WebDriverEngine
{

    using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
    public interface IWebDriverEngine
    {
        void CloseWebDriver();
        string Execute(ExecuteConfig config);
    }
}
