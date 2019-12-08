namespace NTT.ScrapingLib.Model.ScrapingConfig.Execute
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using NTT.ScrapingLib.Model.WebDriver;
    using System;

    public class WebDriveExecuteConfig: ExecuteConfig
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public EventType EventType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FindElementType FindType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ResponseType ResponseType { get; set; }

        public override void SetData(JToken excuteConfig)
        {
            base.SetData(excuteConfig);

            var textActionType = excuteConfig.SelectToken("ActionType").Value<string>();
            EventType = (EventType)Enum.Parse(typeof(EventType), textActionType);

            var textFindType = excuteConfig.SelectToken("FindType").Value<string>();
            FindType = (FindElementType)Enum.Parse(typeof(FindElementType), textFindType);

            var textResponseType = excuteConfig.SelectToken("ResponseType").Value<string>();
            ResponseType = (ResponseType)Enum.Parse(typeof(ResponseType), textResponseType);

        }

    }
}
