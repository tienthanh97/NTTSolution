using HtmlAgilityPack;
using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
using System;
using System.Collections.Generic;

namespace NTT.ScrapingLib.ScrapingHelper
{
    public class HTMLValueHelper : IScrapingHelper
    {
        string _document;
        public HTMLValueHelper(string document)
        {
            _document = document;
        }

        public Dictionary<string, string> ScrapeData(ExecuteConfig executeConfig)
        {
            var result = new Dictionary<string, string>();
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(_document);

            var scrapeDatas = htmlDoc.DocumentNode.SelectNodes(executeConfig.Pattern);
            if (scrapeDatas != null)
            {
                foreach (var scrapeData in scrapeDatas)
                {
                    string key = Guid.NewGuid().ToString() ;
                    string dicValue;
                    dicValue = scrapeData.InnerText;
                    result.Add(key, dicValue);
                }
            }
            return result;
        }
    }
}
