

namespace NTT.ScrapingLib.Model.ScrapingConfig.Execute
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NTT.ScrapingLib.Model.ScrapingConfig.Enums;
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute.TextHandle;
    using System;
    public class TextExecutorConfig: ExecuteConfig
    {
        /// <summary>
        /// Gets or sets the text handle configuration.
        /// </summary>
        /// <value>
        /// The text handle configuration.
        /// </value>
         public TextHandleBaseConfig TextHandleConfig { get; set; }

        public override void SetData(JToken excuteConfig)
        {
            base.SetData(excuteConfig);
            TextHandleConfig = BuildTextHanldeConfig(excuteConfig);
        }

        private TextHandleBaseConfig BuildTextHanldeConfig(JToken textconfig)
        {
            TextHandleBaseConfig result = null;  
            var textHanldeType = textconfig.SelectToken("TextHandleConfig.TextHanldeType").Value<string>();
            var handldeType = (TextHanldeType)Enum.Parse(typeof(TextHanldeType), textHanldeType);
            var textHandleConfig = textconfig.SelectToken("TextHandleConfig");
            switch (handldeType)
            {
                case TextHanldeType.Split:
                    result = JsonConvert.DeserializeObject<TextSplitingHandleConfig>(textHandleConfig.ToString());
                    break;
                case TextHanldeType.Regex:
                    result = JsonConvert.DeserializeObject<TextRegexHandleConfig>(textHandleConfig.ToString());
                    break;
                case TextHanldeType.Join:
                 //   result = JsonConvert.DeserializeObject<TextHandleConfig>(textconfig.ToString());
                    break;
                case TextHanldeType.Replace:
                    result = JsonConvert.DeserializeObject<TextReplaceHandleConfig>(textHandleConfig.ToString());
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
