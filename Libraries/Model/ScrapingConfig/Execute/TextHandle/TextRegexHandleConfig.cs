namespace NTT.ScrapingLib.Model.ScrapingConfig.Execute.TextHandle
{
    public class TextRegexHandleConfig :TextHandleBaseConfig
    {
        /// <summary>
        /// Gets or sets the regex expression.
        /// </summary>
        /// <value>
        /// The regex expression.
        /// </value>
        public string RegexExpression { get; set; }

        /// <summary>
        /// Gets or sets the index of the group.
        /// </summary>
        /// <value>
        /// The index of the group.
        /// </value>
        public int GroupIndex { get; set; } = 1;
    }
}
