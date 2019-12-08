

namespace NTT.ScrapingLib.Model.ScrapingConfig.Execute
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using NTT.ScrapingLib.Model.ScrapingConfig.Enums;
    using System;

    public class ExecuteConfig
    {
        /// <summary>
        /// Gets or sets the pattern.
        /// </summary>
        /// <value>
        /// The pattern.
        /// </value>
        public string Pattern { get; set; }

        /// <summary>
        /// Gets or sets the type of the scrap.
        /// </summary>
        /// <value>
        /// The type of the scrap.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public ScrapingType ScrapeType { get; set; }

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public int Interval { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="excuteConfig">The excute configuration.</param>
        public virtual void SetData(JToken excuteConfig)
        {
            var str = excuteConfig.ToString();
            var tempBuildType = excuteConfig.SelectToken("ScrapeType").Value<string>();
            ScrapeType = (ScrapingType)Enum.Parse(typeof(ScrapingType), tempBuildType);
            Pattern = excuteConfig.SelectToken("Pattern").Value<string>();
            Interval= excuteConfig.SelectToken("Interval").Value<int>();
            Description = excuteConfig.SelectToken("Description").Value<string>();
        }
    }
}
