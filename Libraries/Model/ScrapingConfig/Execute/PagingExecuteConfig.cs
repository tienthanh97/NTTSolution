

namespace NTT.ScrapingLib.Model.ScrapingConfig.Execute
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using NTT.ScrapingLib.Model.ScrapingConfig.Enums;
    public class PagingExecuteConfig: ExecuteConfig
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public UrlBuildType UrlBuildType { get; set; }

        /// <summary>
        /// Gets or sets to page.
        /// </summary>
        /// <value>
        /// To page.
        /// </value>
        public int ToPage { get; set; }

        /// <summary>Gets or sets from page.</summary>
        /// <value>From page.</value>
        public int FromPage { get; set; } = 0;

        /// <summary>
        /// Gets or sets the paging pattern.
        /// </summary>
        /// <value>
        /// The paging pattern.
        /// </value>
        public string PagingPattern { get; set; }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="token">The token.</param>
        public override void SetData(JToken token)
        {
            base.SetData(token);
            ToPage = token.SelectToken("PageQuantity").Value<int>();
            PagingPattern = token.SelectToken("PagingPattern").Value<string>();
            var urlBuildType = token.SelectToken("UrlBuildType").Value<string>();
            UrlBuildType = (UrlBuildType)Enum.Parse(typeof(UrlBuildType), urlBuildType);
        }
    }
}
