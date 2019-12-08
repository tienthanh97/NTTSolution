using Newtonsoft.Json.Linq;
using NTT.ScrapingLib.ConfigHandler;
using NTT.ScrapingLib.ConfigHandler.Iterator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NTT.ScrapingLib.ConfigHandler
{
    public class StorageStepConfig : ScrapingConfigBase
    {
        /// <summary>
        /// Gets or sets the name of the data.
        /// </summary>
        /// <value>
        /// The name of the data.
        /// </value>
        public string DataName { get; set; }

        public StorageStepConfig(
            Dictionary<string, List<Dictionary<string, string>>> responseData = null,
               List<string> depentData = null
           ) : base(responseData)
        {
            _tempData = new List<string>();
            _dependData = depentData;
        }

        /// <summary>
        /// Adds the specified scrap configuration.
        /// </summary>
        /// <param name="ScrapingConfig"></param>
        public override void Add(ScrapingConfigBase ScrapingConfig)
        {
            NextSteps.Add(ScrapingConfig);
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="token">The token.</param>
        public override void SetData(JToken token)
        {
            base.SetData(token);
            DataName = token.SelectToken("DataName").Value<string>();
        }
        public override void Execute()
        {
            IEnumerator iEnumerator = NextSteps.GetEnumerator();
            foreach (var depend in _dependData)
                {
                    // Create Temp Data to store
                    var scrapingResult = new List< Dictionary<string, string>>();
                    // Execute Child Step
                    while (iEnumerator.MoveNext())
                    {
                    ScrapingConfigBase config = (ScrapingConfigBase)iEnumerator.Current;
                        var dependData = new List<string> { depend };
                        config.SetDepentData(dependData);
                        config.SetStoreData(scrapingResult);
                        config.Execute();
                    }
                    iEnumerator.Reset();
                    // Store to Memmory
                    
                    StoreData(scrapingResult);
                    
                }
            
        }

        public override IEnumerator GetChild()
        {
            return new ProcessStepIterator(NextSteps);
        }

        protected override void StoreData(List<Dictionary<string, string>> storageData)
        {
            if (_responseData != null)
            {
                string key = DataName;
                if (!_responseData.TryGetValue(key, out List<Dictionary<string, string>> dicResult))
                {
                    // Incase new Data
                    dicResult = new List<Dictionary<string, string>>();
                    _responseData.Add(key, dicResult);
                }
                dicResult.AddRange(storageData);

                // Show ScrapingData to console 
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine($"_____{DataName}______");
                foreach (var data in storageData)
                {
                    foreach (var item in data)
                    {
                        Console.WriteLine($"Key :{ item.Key } Value : {item.Value} ");
                    }
                    Console.WriteLine();
                }
               
                Console.WriteLine($"*************{DataName} END *************");
            }
        }


    }
}
