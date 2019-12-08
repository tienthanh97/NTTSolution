
namespace NTT.ScrapingLib.ConfigHandler
{
    using Newtonsoft.Json.Linq;
    using NTT.ScrapingLib.ConfigHandler.Factory;
    using NTT.ScrapingLib.ConfigHandler.Iterator;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    public class DataExtractionStepConfig : ScrapingConfigBase
    {
        /// <summary>
        /// Gets or sets the name of the attribute.
        /// </summary>
        /// <value>
        /// The name of the attribute.
        /// </value>
        public string AttributeName { get; set; }

        /// <summary>
        /// Adds the specified scrap configuration.
        /// </summary>
        /// <param name="ScrapingConfig"></param>
        public override void Add(ScrapingConfigBase ScrapingConfig)
        {
            NextSteps.Add(ScrapingConfig);
        }

        public override void Execute()
        {
            StoreData(_storeData);
        }

        public override IEnumerator GetChild()
        {
            return new DataExtractionStepIterator(this);
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="token">The token.</param>
        public override void SetData(JToken token)
        {
            base.SetData(token);
            if (!token.HasValues)
            {

            }
           AttributeName = token.SelectToken("AttributeName").Value<string>();
        }

        /// <summary>
        /// Stores the data.
        /// </summary>
        /// <param name="storageData">The storage data.</param>
        protected override void StoreData(List<Dictionary<string, string>> storageData)
        {
            var executeConfig = ExecuteConfig;
            var dependData = _dependData.FirstOrDefault();
            var scraperHandler = ScrapingHelperFactory.GetScrapingHelper(executeConfig.ScrapeType, dependData);
            var collectData = scraperHandler.ScrapeData(this.ExecuteConfig);
            var key = AttributeName;
            string dicValue = string.Empty;
            if (collectData!=null && collectData.Any())
            {
                dicValue = collectData.First().Value;
            }
            var data = storageData.Any() ? storageData.Last() : new Dictionary<string, string>();

            if (!data.Any())
            {
                data.Add(key, dicValue);
                storageData.Add(data);
            }
            else if (!data.Any(x => x.Key.Equals(key)))
            {
                // Add new item for dictionary if not duplicate key
                data.Add(key, dicValue);
            }
            else
            {
                bool canAdd=true;
                // Create new record when duplicate key
                var newData= new Dictionary<string, string>();
                // Add relation Data
                foreach (var item in data.ToList())
                {
                    if (item.Key.Equals(key))
                    {
                        canAdd = false;
                        newData.Add(key,dicValue);
                    }
                    if (canAdd)
                    {
                        newData.Add(item.Key, item.Value);
                    }
                    
                }
                 storageData.Add(newData);
            }
        }

        /// <summary>
        /// Renews the name of the dic by attribute.
        /// </summary>
        /// <param name="dic">The dic.</param>
        private void RenewDicByAttributeName(Dictionary<string, string> dic, string attributeName)
        {
            bool canGetKey = false;

            var listItem = dic.ToList();
            var keys = new List<string>();
            foreach (var item in listItem)
            {
                if (item.Key.Equals(attributeName))
                {
                    canGetKey = true;
                }
                if (canGetKey)
                {
                    keys.Add(item.Key);
                }
            }
            if (keys.Any())
            {
                foreach (var key in keys)
                {
                    dic.Remove(key);
                }
            }
            
        }


    }
}
