

namespace NTT.ScrapingLib.ScrapingHelper
{
    using HtmlAgilityPack;
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
    using System;
    using System.Collections.Generic;
    public class HTMLDocHelper : IScrapingHelper
    {
        string _document;
        public HTMLDocHelper(string document)
        {
            _document = document;
        }
        public Dictionary<string, string> ScrapeData(ExecuteConfig executeConfig)
        {
           
            var result = new Dictionary<string, string>();
            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(_document);

                var scrapeDatas = htmlDoc.DocumentNode.SelectNodes(executeConfig.Pattern);
                if (scrapeDatas != null)
                {
                    foreach (var scrapeData in scrapeDatas)
                    {
                        string key = Guid.NewGuid().ToString();
                        string dicValue = "";
                        dicValue = scrapeData.InnerHtml;
                        result.Add(key, dicValue);
                    }
                }
            }
            catch (Exception ex )
            {
                
            }
          
          

            return result;
        }

        
    }
}
