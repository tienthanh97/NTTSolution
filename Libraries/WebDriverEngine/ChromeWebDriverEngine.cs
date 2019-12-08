

namespace NTT.ScrapingLib.WebDriverEngine
{
    using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
    using NTT.ScrapingLib.Model.WebDriver;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    public class ChromeWebDriverEngine:IWebDriverEngine,IDisposable
    {
        #region Variable 

        /// <summary>
        /// The instance
        /// </summary>
        private static ChromeWebDriverEngine instance;

        /// <summary>
        /// Gets or sets the driver.
        /// </summary>
        /// <value>
        /// The driver.
        /// </value>
        private ChromeDriver _driver { get; set; }

        /// <summary>
        /// Gets or sets the elements.
        /// </summary>
        /// <value>
        /// The elements.
        /// </value>
        private List<IWebElement> elements { get; set; }

        /// <summary>
        /// Gets or sets the currentelement.
        /// </summary>
        /// <value>
        /// The currentelement.
        /// </value>
        private IWebElement _currentelement { get; set; }

        #endregion

        #region Constructor
        public ChromeWebDriverEngine()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        #endregion

        #region Public Methods
        public string Execute(ExecuteConfig config)
        {
            var executeConfig = (WebDriveExecuteConfig)config;
            string result = "";
            switch (executeConfig.EventType)
            {
                case EventType.Click:
                    Click();
                    break;
                case EventType.Navigate:
                    Navigate(executeConfig.Pattern);
                    break;
                case EventType.Find:
                    FindElement(executeConfig.FindType, executeConfig.Pattern);
                    break;
                case EventType.Get:
                    GetElement(executeConfig.FindType, executeConfig.Pattern);
                    break;
                case EventType.FindFromElements:
                    FindFromElements(executeConfig.FindType, executeConfig.Pattern);
                    break;
                default:
                    break;
            }

            var responseType = executeConfig.ResponseType;
            // Get Data If needed
            if (_driver!=null)
            {
                result = GetDataFromDriver(responseType);
            }
            return result;
        }

        public void CloseWebDriver()
        {
            this._driver.Close();
        }





        #endregion

        #region Private  Methods

        /// <summary>
        /// Navigates the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        private void Navigate(string url)
        {
            if (_driver != null)
            {
                _driver.Navigate().GoToUrl(url);
            }
        }

        /// <summary>
        /// Gets the data from driver.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="responseType">Type of the response.</param>
        /// <returns></returns>
        private string GetDataFromDriver(ResponseType responseType)
        {
            string result = "";
            if (_driver != null)
            {
                switch (responseType)
                {
                    case ResponseType.Url:
                        result = _driver.Url;
                        break;
                    case ResponseType.PageSource:
                        result = _driver.PageSource;
                        break;
                    default:
                        break;
                }
            }
            return result;
        }



        /// <summary>
        /// Clicks the specified driver.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="config">The configuration.</param>
        private void Click()
        {
            _currentelement.Click();
        }

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private void GetElement(FindElementType type, String pattern)
        {
            switch (type)
            {
                case FindElementType.GetById:
                    _currentelement = _driver.FindElementById(pattern);
                    break;
                case FindElementType.GetByClassName:
                    _currentelement = _driver.FindElementByClassName(pattern);
                    break;
                case FindElementType.GetByXPath:
                    _currentelement = _driver.FindElementByXPath(pattern);
                    break;
                case FindElementType.GetByTagName:
                    _currentelement = _driver.FindElementByTagName(pattern);
                    break;
                case FindElementType.GetByCssSelector:
                    _currentelement = _driver.FindElementByCssSelector(pattern);
                    break;
                case FindElementType.GetByLinkText:
                    _currentelement = _driver.FindElementByLinkText(pattern);
                    break;
                case FindElementType.GetByName:
                    _currentelement = _driver.FindElementByName(pattern);
                    break;
                case FindElementType.GetByPartialLinkText:
                    _currentelement = _driver.FindElementByPartialLinkText(pattern);
                    break;
                case FindElementType.GetByElementText:
                    _currentelement = GetByElementText(pattern);
                    break;
                default:
                    _currentelement = _driver.FindElementById(pattern);
                    break;
            }
        }

        /// <summary>
        /// Finds the element.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="pattern">The pattern.</param>
        private void FindElement(FindElementType type, string pattern)
        {
            switch (type)
            {
                case FindElementType.GetByClassName:
                    elements = _driver.FindElementsByClassName(pattern).ToList();
                    break;
                case FindElementType.GetByXPath:
                    elements = _driver.FindElementsByXPath(pattern).ToList();
                    break;
                case FindElementType.GetByTagName:
                    elements = _driver.FindElementsByTagName(pattern).ToList();
                    break;
                case FindElementType.GetByCssSelector:
                    elements = _driver.FindElementsByCssSelector(pattern).ToList();
                    break;
                case FindElementType.GetByLinkText:
                    elements = _driver.FindElementsByLinkText(pattern).ToList();
                    break;
                case FindElementType.GetByName:
                    elements = _driver.FindElementsByName(pattern).ToList();
                    break;
                default:
                    elements = _driver.FindElementsByClassName(pattern).ToList();
                    break;
            }
        }

        /// <summary>
        /// Finds from elements.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="pattern">The pattern.</param>
        private void FindFromElements(FindElementType type, string pattern)
        {
            switch (type)
            {
                case FindElementType.GetById:
                    elements = _currentelement.FindElements(By.Id(pattern)).ToList();
                    break;
                case FindElementType.GetByClassName:
                    elements = _currentelement.FindElements(By.ClassName(pattern)).ToList();
                    break;
                case FindElementType.GetByXPath:
                    elements = _currentelement.FindElements(By.XPath(pattern)).ToList();
                    break;
                case FindElementType.GetByTagName:
                    elements = _currentelement.FindElements(By.TagName(pattern)).ToList();
                    break;
                case FindElementType.GetByCssSelector:
                    elements = _currentelement.FindElements(By.CssSelector(pattern)).ToList();
                    break;
                case FindElementType.GetByLinkText:
                    elements = _currentelement.FindElements(By.LinkText(pattern)).ToList();
                    break;
                case FindElementType.GetByName:
                    elements = _currentelement.FindElements(By.Name(pattern)).ToList();
                    break;
                case FindElementType.GetByPartialLinkText:
                    elements = _currentelement.FindElements(By.PartialLinkText(pattern)).ToList();
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Gets the by element text.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        private IWebElement GetByElementText(string pattern)
        {
            IWebElement result = null;
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    string elementText = element.Text;
                    if (!string.IsNullOrEmpty(elementText))
                    {
                        if (elementText.ToUpper().Trim().Contains(pattern.ToUpper().Trim()))
                        {
                            result = element;
                            break;
                        }
                    }
                    Thread.Sleep(2000);
                }
            }
            return result;
        }

        bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }

        public void Dispose()
        {
            _driver.Close();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
