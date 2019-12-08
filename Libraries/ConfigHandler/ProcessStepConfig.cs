using NTT.ScrapingLib.ConfigHandler.Iterator;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NTT.ScrapingLib.ConfigHandler
{
    public class ProcessStepConfig : ScrapingConfigBase
    {

        public ProcessStepConfig(
             Dictionary<string, List<Dictionary<string, string>>> responseData = null,
                List<string> depentData = null
            ) : base(responseData)
        {
            _tempData = new List<string>();
            _dependData = depentData;
        }

        public override void Add(ScrapingConfigBase ScrapingConfig)
        {
            NextSteps.Add(ScrapingConfig);
        }

        public override void Execute()
        {
            IEnumerator iEnumerator = NextSteps.GetEnumerator();
           
            if (_dependData!=null&&_dependData.Any())
            {
              
                foreach (var depend in _dependData)
                {
                    ProcessData(depend, iEnumerator);
                }
            }
            else
            {
                ProcessData("", iEnumerator);
            }
          
        }

        /// <summary>
        /// Childses this instance.
        /// </summary>
        /// <returns></returns>
        public override IEnumerator GetChild()
        {
            return new ProcessStepIterator(NextSteps);
        }

        private void ProcessData(string document, IEnumerator iEnumerator)
        {
            var collectData = ScrapeData(document);
            foreach (var data in collectData)
            {
                _tempData = new List<string>();
                var catchdata = new Dictionary<string, string>
                {
                    { data.Key, data.Value }
                };
                this.StoreToTempData(catchdata);
                // Execute Child Step
                while (iEnumerator.MoveNext())
                {
                    ScrapingConfigBase config = (ScrapingConfigBase)iEnumerator.Current;
                    config.SetDepentData(_tempData);
                    config.SetStoreData(_storeData);
                    config.Execute();
                }
                iEnumerator.Reset();
            }
            
        }
    }
}
