

namespace NTT.ScrapingLib.Model.ScrapingConfig.Execute
{
    using Newtonsoft.Json.Linq;
    public class HTMLAttributeExecuteConfig :ExecuteConfig
    {
        public string HtmlAttribute { get; set; }

        public string EnclosePrevious  { get; set; }
        public override void SetData(JToken excuteConfig)
        {
            base.SetData(excuteConfig);
            HtmlAttribute = excuteConfig.SelectToken("HtmlAttribute").Value<string>();
            EnclosePrevious = excuteConfig.SelectToken("EnclosePrevious").Value<string>();
        }

    }
}
