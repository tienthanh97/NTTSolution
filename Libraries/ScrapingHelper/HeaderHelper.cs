

namespace NTT.ScrapingLib.ScrapingHelper
{
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
    using System;
    using System.Collections.Generic;

    public class HeaderHelper:IScrapingHelper
    {
        private string _document;
        private RequestHelper _scrape;
        public HeaderHelper(string document)
        {
            _document = document;
            _scrape = new RequestHelper();
        }

        public Dictionary<string, string> ScrapeData(ExecuteConfig executeConfig)
        {
            var result = new Dictionary<string, string>();
            try
            {
                //if (executeConfig.HeaderConfigs!=null)
                //{
                //    var url = executeConfig?.Pattern;
                //    var docResult = _scrape.GetDocumentWithHeader(url, executeConfig.HeaderConfigs, executeConfig.Interval);
                //    string key = string.IsNullOrEmpty(executeConfig.AttributeName) ?
                //              Guid.NewGuid().ToString() : executeConfig.AttributeName;
                //    result.Add(key, docResult);
                //}
                // Get URL
              
            }
            catch (Exception)
            {

            }

            return result;

        }
    }
}
