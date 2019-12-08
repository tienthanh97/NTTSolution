namespace NTT.ScrapingLib.Model.ScrapingConfig.Execute.TextHandle
{
    public class TextSplitingHandleConfig:TextHandleBaseConfig
    {
        /// <summary>
        /// Gets or sets the split expression.
        /// </summary>
        /// <value>
        /// The split expression.
        /// </value>
        public string SplitExpression { get; set; }

        /// <summary>
        /// Gets or sets the index of the take.
        /// </summary>
        /// <value>
        /// The index of the take.
        /// </value>
        public int TakeIndex { get; set; }
    }
}
