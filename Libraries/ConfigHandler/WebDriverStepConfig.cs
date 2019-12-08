using NTT.ScrapingLib.ConfigHandler.Iterator;
using NTT.ScrapingLib.Model.ScrapingConfig.Enums;
using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
using NTT.ScrapingLib.Model.WebDriver;
using NTT.ScrapingLib.WebDriverEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NTT.ScrapingLib.ConfigHandler
{
    public class WebDriverStepConfig : ScrapingConfigBase
    {
        public bool IsExecuteActionbyDepentData { get; set; } = false;
        public override void Add(ScrapingConfigBase ScrapingConfig)
        {
            NextSteps.Add(ScrapingConfig);
        }
        
        public override void Execute()
        {
            if (_webDrive == null)
            {
                _webDrive = new ChromeWebDriverEngine();
            }
            var excConfic = (WebDriveExecuteConfig)ExecuteConfig;
            if (IsExecuteActionbyDepentData)
            {
                foreach (var data in _dependData)
                {
                    excConfic.Pattern = data;
                    ExecuteWebDriverAction(excConfic);
                }
            }
            else
            {
                ExecuteWebDriverAction(excConfic);
            }
        }

        private void ExecuteWebDriverAction(WebDriveExecuteConfig excConfic)
        {
            var result = _webDrive.Execute(excConfic);
            Console.WriteLine("*******************");
            Console.WriteLine(result);
            if (excConfic.ResponseType == ResponseType.PageSource)
            {
                // Web Driver always has only one tempData Item
                _tempData = new List<string>();
                var catchdata = new Dictionary<string, string>
                {
                    { Guid.NewGuid().ToString(), result }
                };
                this.StoreToTempData(catchdata);
            }
            IEnumerator iEnumerator = NextSteps.GetEnumerator();
            ExcuteChildConfig(iEnumerator);
        }

        public override IEnumerator GetChild()
        {
            return new ProcessStepIterator(NextSteps);
        }

        protected override void ExcuteChildConfig(IEnumerator iEnumerator)
        {
            // Quit Webdriver If WebDriver  use in childs step 
            var childTypes = new List<StepType>();
            SetStepTypeOfChilds(childTypes);
            while (iEnumerator.MoveNext())
            {
                ScrapingConfigBase config = (ScrapingConfigBase)iEnumerator.Current;
                config.SetDepentData(_tempData);
                config.SetStoreData(_storeData);
                if (childTypes.Any(x => x == StepType.WebDriver))
                {
                    config.SetWebDriver(_webDrive);
                }
                config.Execute();
                
            }
            iEnumerator.Reset();
        }
    }
}
