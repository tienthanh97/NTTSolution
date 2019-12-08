

namespace NTT.ScrapingLib.ConfigHandler
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using NTT.ScrapingLib.ConfigHandler.Iterator;
    using NTT.ScrapingLib.Model.ScrapingConfig.Enums;
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute.BuildTempExecute;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class BuildTempDataStepConfig : ScrapingConfigBase
    {
        public BuildTempDataStepConfig()
        {
            _tempData = new List<string>();
        }

        /// <summary>
        /// Gets or sets the type of the build temporary.
        /// </summary>
        /// <value>
        /// The type of the build temporary.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public TempBuildType TempBuildType { get; set; }

        public override void Add(ScrapingConfigBase ScrapingConfig)
        {
            NextSteps.Add(ScrapingConfig);
        }

        public override void Execute()
        {
            switch (TempBuildType)
            {
                case TempBuildType.DocJoinPattern:
                    break;
                case TempBuildType.PatternJoinDoc:
                    break;
                case TempBuildType.DocReplacePattern:
                    DocReplacePattern();
                    break;
                case TempBuildType.PatternReplaceDoc:
                    break;
                case TempBuildType.SortTemp:
                    break;
                case TempBuildType.FilteringTemp:
                    break;
                case TempBuildType.GroupingTemp:
                    GroupingData();
                    break;
                default:
                    break;
            }
        }

        public override IEnumerator GetChild()
        {
            return new ProcessStepIterator(NextSteps);
        }

        private void GroupingData()
        {
            IEnumerator iEnumerator = NextSteps.GetEnumerator();
            foreach (var dependData in _dependData)
            {

            }
            ExcuteChildConfig(iEnumerator);
        }

        private void DocReplacePattern()
        {
            IEnumerator iEnumerator = NextSteps.GetEnumerator();
            var config = (ReplaceTempExecuteConfig)ExecuteConfig;
            foreach (var data in _dependData)
            {
                var pattern = config.Pattern;
                var newData = pattern.Replace(config.ReplacePattern, data);
                _tempData .Add(newData);
            }
            ExcuteChildConfig(iEnumerator);
        }

        public override void SetData(JToken token)
        {
            base.SetData(token);
            var tempBuildType = token.SelectToken("TempBuildType").Value<string>();
            TempBuildType = (TempBuildType)Enum.Parse(typeof(TempBuildType), tempBuildType);
        }
    }
}
