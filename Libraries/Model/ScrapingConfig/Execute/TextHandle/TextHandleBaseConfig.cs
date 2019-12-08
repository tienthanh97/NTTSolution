using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NTT.ScrapingLib.Model.ScrapingConfig.Enums;

namespace NTT.ScrapingLib.Model.ScrapingConfig.Execute.TextHandle
{
    public class TextHandleBaseConfig
    {
        /// <summary>
        /// Gets or sets the type of the text hanlde.
        /// </summary>
        /// <value>
        /// The type of the text hanlde.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public TextHanldeType TextHanldeType { get; set; }
    }
}
