using Newtonsoft.Json.Linq;

namespace NTT.ScrapingLib.Model.ScrapingConfig.Execute.BuildTempExecute
{
    public class ReplaceTempExecuteConfig:ExecuteConfig
    {
        public string ReplacePattern { get; set; }
        public override void SetData(JToken excuteConfig)
        {
            base.SetData(excuteConfig);
            ReplacePattern = excuteConfig.SelectToken("ReplacePattern").Value<string>();
        }
    }
}
