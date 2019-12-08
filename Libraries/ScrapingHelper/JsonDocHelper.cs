

namespace NTT.ScrapingLib.ScrapingHelper
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
    using System;
    using System.Collections.Generic;

    public class JsonDocHelper : IScrapingHelper
    {
        string _document;
        public JsonDocHelper(string document)
        {
            _document = document;
        }
        public Dictionary<string, string> ScrapeData(ExecuteConfig executeConfig)
        {
            var result = new Dictionary<string, string>();
            var jDocument = JsonConvert.DeserializeObject<JToken>(_document);
            var scrapeDatas = jDocument.SelectTokens(executeConfig.Pattern);
            foreach (var scrapeData in scrapeDatas)
            {
                string dicValue = scrapeData.ToString();
                string key = Guid.NewGuid().ToString();
                result.Add(key, dicValue);
            }

            return result;
        }
    }
}
