namespace NTT.ScrapingLib.ScrapingHelper
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
    using System;
    using System.Collections.Generic;
    public class JsonValueHelper : IScrapingHelper
    {
        string _document;
        public JsonValueHelper(string document)
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
                string dicValue = scrapeData.Value<string>();
                string key = Guid.NewGuid().ToString();
                result.Add(key, dicValue);
            }

            return result;
        }
    }
}
