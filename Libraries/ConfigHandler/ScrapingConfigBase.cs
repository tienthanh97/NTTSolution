

namespace NTT.ScrapingLib.ConfigHandler
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using NTT.ScrapingLib.ConfigHandler.Factory;
    using NTT.ScrapingLib.Model.ScrapingConfig.Enums;
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute.BuildTempExecute;
    using NTT.ScrapingLib.WebDriverEngine;

    public abstract class ScrapingConfigBase
    {
        #region Variable

        /// <summary>
        /// The catch data
        /// </summary>
        protected List<string> _tempData;

        /// <summary>
        /// The depend data
        /// </summary>
        protected List<string> _dependData;

        /// <summary>
        /// The store data
        /// </summary>
        protected List<Dictionary<string, string>> _storeData;
        
        /// <summary>
        /// The web drive
        /// </summary>
        protected IWebDriverEngine _webDrive;

        /// <summary>
        /// The response data
        /// </summary>
        protected Dictionary<string, List<Dictionary<string, string>>> _responseData;

        #endregion

        #region Constructor

        public ScrapingConfigBase(Dictionary<string, List<Dictionary<string, string>>> responseData = null)
        {
            _responseData = responseData;
        }

        #endregion


        #region Properties

        public Guid StepId { get; set; }
        public Guid ParentId { get; set; }

        /// <summary>
        /// Gets or sets the execute configuration.
        /// </summary>
        /// <value>
        /// The execute configuration.
        /// </value>
        public virtual ExecuteConfig ExecuteConfig { get; set; }

        /// <summary>
        /// Gets or sets the type of the step.
        /// </summary>
        /// <value>
        /// The type of the step.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public StepType StepType { get; set; }

        public string StepName { get; set; }

        /// <summary>
        /// The childs
        /// </summary>
        protected List<ScrapingConfigBase> NextSteps = new List<ScrapingConfigBase>();

        #endregion

        #region abstracts

        /// <summary>
        /// Adds the specified scrap configuration.
        /// </summary>
        /// <param name="ScrapConfig">The scrap configuration.</param>
        public abstract void Add(ScrapingConfigBase ScrapingConfig);

        /// <summary>
        /// Childses this instance.
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator GetChild();

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public abstract void Execute();



        #endregion

        #region public methods

        /// <summary>
        /// Sets the depent data.
        /// </summary>
        /// <param name="data">The data.</param>
        public virtual void SetDepentData(List<string> data)
        {
            _dependData = data;
        }

        /// <summary>
        /// Gets the depent data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public virtual List<string> GetDepentData()
        {
            return _dependData;
        }

        /// <summary>
        /// Gets the catch data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public virtual List<string> GetCatchData()
        {
            return _tempData;
        }

        /// <summary>
        /// Gets the store data.
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, string>> GetStoreData()
        {
            return _storeData;
        }

        /// <summary>
        /// Sets the store data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void SetStoreData(List<Dictionary<string, string>> data)
        {
            _storeData = data;
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="token">The token.</param>
        public virtual void SetData(JToken token)
        {
            StepName = token.SelectToken("StepName").Value<string>();
            string stepIdStr = token.SelectToken("StepId").Value<string>();
            StepId = Guid.Parse(stepIdStr);
            string parentIdStr = token.SelectToken("ParentId").Value<string>();
            ParentId = Guid.Parse(parentIdStr);
            var excuteConfig = token.SelectToken("ExecuteConfig");
            if (!excuteConfig.HasValues)
            {
                this.ExecuteConfig = null;
            }
            else
            {
                this.ExecuteConfig = BuildExecuteConfig(excuteConfig);
            }


        }

        public void SetWebDriver(IWebDriverEngine driver)
        {
            _webDrive = driver;
        }

        protected ExecuteConfig BuildExecuteConfig(JToken config)
        {
            ExecuteConfig result = null;
            var type = config.SelectToken("ScrapeType").Value<string>();
            var stepType = (ScrapingType)Enum.Parse(typeof(ScrapingType), type);
            switch (stepType)
            {
                case ScrapingType.HTMLValue:
                case ScrapingType.HTMLDoc:
                case ScrapingType.JsonDoc:
                case ScrapingType.JsonVlue:
                    result = JsonConvert.DeserializeObject<ExecuteConfig>(config.ToString());
                    break;
                case ScrapingType.ApiUrl:
                case ScrapingType.WebUrl:
                    result = JsonConvert.DeserializeObject<NavigateExecuteConfig>(config.ToString());
                    break;
                case ScrapingType.Text:
                    result = new TextExecutorConfig();
                    result.SetData(config);
                    break;
                case ScrapingType.HTMLAttribute:
                    result = JsonConvert.DeserializeObject<HTMLAttributeExecuteConfig>(config.ToString());
                    break;
                case ScrapingType.WebDriver:
                    break;
                case ScrapingType.ReplaceTemp:
                    result = JsonConvert.DeserializeObject<ReplaceTempExecuteConfig>(config.ToString());
                    break;
                case ScrapingType.Paging:
                    result = JsonConvert.DeserializeObject<PagingExecuteConfig>(config.ToString());
                    break;
                case ScrapingType.Header:
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// Sets the response data.
        /// </summary>
        /// <param name="data">The data.</param>
        public virtual void SetResponseData(Dictionary<string, List<Dictionary<string, string>>> data)
        {
            _responseData = data;
            IEnumerator childs = NextSteps.GetEnumerator();
            while (childs.MoveNext())
            {
                ScrapingConfigBase config = (ScrapingConfigBase)childs.Current;
                config.SetResponseData(data);
            }
        }

        /// <summary>
        /// Gets the response data.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Dictionary<string, string>>> GetResponseData()
        {
            return _responseData;
        }

        #endregion

        #region protected methods

        /// <summary>
        /// Stores the data.
        /// </summary>
        /// <param name="data">The data.</param>
        protected virtual void StoreData(List<Dictionary<string, string>> StorageData)
        {

        }

        protected Dictionary<string, string> ScrapeData(string Source = "")
        {
            var scraperHandler = ScrapingHelperFactory.GetScrapingHelper(this.ExecuteConfig.ScrapeType, Source);
            var collectData = scraperHandler.ScrapeData(this.ExecuteConfig);
            return collectData;
        }

        protected void StoreToTempData(Dictionary<string, string> data)
        {
            var inputData = data.Select(x => x.Value).ToList();
            _tempData.AddRange(inputData);
        }
        protected virtual void ExcuteChildConfig(IEnumerator iEnumerator)
        {
            while (iEnumerator.MoveNext())
            {
                ScrapingConfigBase config = (ScrapingConfigBase)iEnumerator.Current;
                config.SetDepentData(_tempData);
                config.SetStoreData(_storeData);
                config.Execute();
            }
        }

        protected void SetStepTypeOfChilds(List<StepType> stepTypes)
        {
            IEnumerator iEnumerator = NextSteps.GetEnumerator();
            while (iEnumerator.MoveNext())
            {
                ScrapingConfigBase config = (ScrapingConfigBase)iEnumerator.Current;
                var currentType = config.StepType;
                stepTypes.Add(currentType);
                config.SetStepTypeOfChilds(stepTypes);
            }
        }

     
        #endregion


    }
}
