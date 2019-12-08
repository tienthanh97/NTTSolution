

namespace NTT.ScrapingLib.Model.ScrapingConfig.Execute
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    public class NavigateExecuteConfig:ExecuteConfig
    {
        public bool CanNavigateByDoc { get; set; }
        public Dictionary<string, string> HeaderConfigs { get; set; }
        public override void SetData(JToken excuteConfig)
        {
            base.SetData(excuteConfig);
            CanNavigateByDoc = excuteConfig.SelectToken("CanNavigateByDoc").Value<bool>();
            var headerConfig = excuteConfig.SelectToken("HeaderConfigs");
            if (headerConfig.HasValues)
            {
               HeaderConfigs = JsonConvert.DeserializeObject
                           <Dictionary<string, string>>(headerConfig.ToString());
            }
           
        }
    }
}
