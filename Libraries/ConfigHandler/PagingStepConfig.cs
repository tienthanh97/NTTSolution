namespace NTT.ScrapingLib.ConfigHandler
{
    using NTT.ScrapingLib.ConfigHandler.Iterator;
    using NTT.ScrapingLib.Model.ScrapingConfig.Enums;
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class PagingStepConfig : ScrapingConfigBase
    {
        public override void Add(ScrapingConfigBase ScrapingConfig)
        {
            NextSteps.Add(ScrapingConfig);
        }
        public override IEnumerator GetChild()
        {
            return new ProcessStepIterator(NextSteps);
        }
        public override void Execute()
        {
            //PagingExecuteConfig
            var excConfic = (PagingExecuteConfig)ExecuteConfig;
            BuildUrl(excConfic);
            IEnumerator iEnumerator = NextSteps.GetEnumerator();
            this.ExcuteChildConfig(iEnumerator);
        }

        private void BuildUrl(PagingExecuteConfig config)
        {
            var buildType = config.UrlBuildType;
            switch (buildType)
            {
                case UrlBuildType.ReplaceQuantity:
                        this.BuildUrlWithReplaceQuantity(config);
                    break;
                case UrlBuildType.ReplaceDocument:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Builds the URL with replace quantity.
        /// </summary>
        /// <param name="config">The configuration.</param>
        private void BuildUrlWithReplaceQuantity(PagingExecuteConfig config)
        {
            var toPage = config.ToPage;
            _tempData = new List<string>();
            var urlDic = new Dictionary<string, string>();
            for (int i = config.FromPage; i <= toPage; i++)
            {
                var url = config.Pattern.Replace(config.PagingPattern, i.ToString());
                urlDic.Add(Guid.NewGuid().ToString(), url);
            }
            this.StoreToTempData(urlDic);
        }


        /// <summary>
        /// Builds the URL with replace document.
        /// </summary>
        /// <param name="config">The configuration.</param>
        private void BuildUrlWithReplaceDocument(PagingExecuteConfig config)
        {
            _tempData = new List<string>();
            var urlDic = new Dictionary<string, string>();
            if (_dependData != null && _dependData.Any())
            {
                foreach (var depend in _dependData)
                {
                    var url = config.Pattern.Replace(config.PagingPattern, depend);
                    urlDic.Add(Guid.NewGuid().ToString(), url);
                }
            }
            this.StoreToTempData(urlDic);
        }
    }
}
