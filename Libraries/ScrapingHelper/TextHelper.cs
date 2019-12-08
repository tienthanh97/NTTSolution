

namespace NTT.ScrapingLib.ScrapingHelper
{
    using NTT.ScrapingLib.Model.ScrapingConfig.Enums;
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute.TextHandle;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class TextHelper : IScrapingHelper
    {
        string _document;
        public TextHelper(string document)
        {
            this._document = document;
        }
        public Dictionary<string, string> ScrapeData(ExecuteConfig ExecuteConfig)
        {
            var result = new Dictionary<string, string>();
            var config = (TextExecutorConfig)ExecuteConfig;
            string key = Guid.NewGuid().ToString();
            // Get Text Handle config
            var textHandleConfig = config.TextHandleConfig;

            string docResult = "";
            if (!string.IsNullOrEmpty(_document))
            {
                switch (textHandleConfig.TextHanldeType)
                {
                    case TextHanldeType.Split:
                        var splitConfig = (TextSplitingHandleConfig)textHandleConfig;
                        docResult = SlipHandler(splitConfig);
                        break;
                    case TextHanldeType.Regex:
                        // Support Regex
                        var regexConfig = (TextRegexHandleConfig)textHandleConfig;
                        docResult = RegexHandler(regexConfig);
                        break;
                    case TextHanldeType.Join:
                        //docResult = JoinText(ExecuteConfig);
                        break;
                    case TextHanldeType.Replace:
                        var replaceConfig = (TextReplaceHandleConfig)textHandleConfig;
                        docResult = ReplaceText(replaceConfig);
                        break;
                    default:
                        docResult = "";
                        break;
                }
            }
            result.Add(key, docResult);
            return result;
        }

        /// <summary>
        /// Slips the handler.
        /// </summary>
        /// <param name="textHandleConfig">The text handle configuration.</param>
        /// <returns></returns>
        private string SlipHandler(TextSplitingHandleConfig textHandleConfig)
        {
            string result = "";
            var charractor = textHandleConfig.SplitExpression;
            var index = textHandleConfig.TakeIndex;
            result = _document.Split(new string[] { charractor }, StringSplitOptions.RemoveEmptyEntries)[index];
            return result;
        }

        /// <summary>
        /// Builds the text.
        /// </summary>
        /// <param name="executeConfig">The execute configuration.</param>
        /// <returns></returns>
        private string ReplaceText(TextReplaceHandleConfig executeConfig)
        {
            string result = "";
            string oldText = executeConfig.OldValue;
            if (!string.IsNullOrEmpty(oldText))
            {
                result = _document.Replace(executeConfig.OldValue, executeConfig.NewValue);
            }
            return result;
        }



        /// <summary>
        /// Regexes the handler.
        /// </summary>
        /// <param name="textHandleConfig">The text handle configuration.</param>
        /// <returns></returns>
        private string RegexHandler(TextRegexHandleConfig textHandleConfig)
        {
            string result = "";
            Regex regex = new Regex(textHandleConfig.RegexExpression);
            Match match = regex.Match(_document);

            if (match.Success)
            {
                result = match.Groups[textHandleConfig.GroupIndex].Value;
            }

            return result;
        }

        /// <summary>
        /// Builds the text.
        /// </summary>
        /// <param name="executeConfig">The execute configuration.</param>
        /// <returns></returns>
        //private string JoinText(ProcessingExecuteConfig executeConfig)
        //{
        //    string result = "";
        //    var textConfig = executeConfig.TextHandleConfig;

        //    if (textConfig!=null && textConfig.JoinTextConfig!=null)
        //    {
        //        if (textConfig.JoinTextConfig.IsDependToJoinData)
        //        {
        //            result = _document + textConfig.JoinTextConfig.JoinData;
        //        }
        //        else
        //        {
        //            result =  textConfig.JoinTextConfig.JoinData + _document ;
        //        }
        //    }
        //    return result;
        //}

        /// <summary>
        /// Replaces the by configuration.
        /// </summary>
        /// <param name="TextHandleConfig">The text handle configuration.</param>
        /// <returns></returns>
        //private string ReplaceByConfig(TextHandleConfig textHandleConfig)
        //{
        //    string result = "";
        //    result = _document.Replace(textHandleConfig.OldData, textHandleConfig.NewData);
        //    return result;
        //}
    }
}
