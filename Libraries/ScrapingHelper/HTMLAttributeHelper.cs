
namespace NTT.ScrapingLib.ScrapingHelper
{
    using HtmlAgilityPack;
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
    using System;
    using System.Collections.Generic;

    public class HTMLAttributeHelper : IScrapingHelper
    {
        string _document;
        public HTMLAttributeHelper(string document)
        {
            _document = document;
        }

        public Dictionary<string, string> ScrapeData(ExecuteConfig executeConfig)
        {
            
            var result = new Dictionary<string, string>();
            try
            {
                var config = (HTMLAttributeExecuteConfig)executeConfig;
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(_document);

                var scrapeDatas = htmlDoc.DocumentNode.SelectNodes(config.Pattern);
                if (scrapeDatas != null)
                {
                    foreach (var scrapeData in scrapeDatas)
                    {
                        string key = Guid.NewGuid().ToString();
                        string dicValue = "";
                        string attr = config.HtmlAttribute;
                        dicValue = scrapeData.Attributes[attr].Value;
                        if (!string.IsNullOrEmpty(config.EnclosePrevious))
                        {
                            dicValue = config.EnclosePrevious + dicValue;
                        }
                        result.Add(key, dicValue);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
