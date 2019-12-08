

namespace NTT.ScrapingLib.ScrapingHelper
{
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
    using System.Collections.Generic;
    public interface IScrapingHelper
    {
        Dictionary<string, string> ScrapeData(ExecuteConfig executeConfig);
    }
}
