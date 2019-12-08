
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NTT.Model.ScrapingData;
using NTT.ScrapingLib.ConfigHandler;
using NTT.ScrapingLib.DataConvertor;
using NTT.ScrapingLib.Model.ScrapingConfig.Enums;
using NTT.ScrapingLib.Model.ScrapingConfig.Execute;
using NTT.ScrapingLib.Model.ScrapingConfig.Execute.BuildTempExecute;
using NTT.ScrapingLib.Model.ScrapingConfig.Execute.TextHandle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RealEstateWorker.Engines
{
    public class ScrapingEngine
    {
        public string BasePath { get; } = AppDomain.CurrentDomain.BaseDirectory;
        public ScrapingConfigBase GetConfig()
        {
            List<ScrapingConfigBase> stepsTemp = new List<ScrapingConfigBase>();

           var GetDocument = new PagingStepConfig()
            {
               StepId = Guid.NewGuid(),
               ParentId = Guid.Empty,
               StepName = "Get Document",
                StepType = StepType.Paging,
                ExecuteConfig = new PagingExecuteConfig
                {
                    Pattern = "https://batdongsan.com.vn/nha-dat-cho-thue/p@page",
                    UrlBuildType = UrlBuildType.ReplaceQuantity,
                    PagingPattern = "@page",
                    ScrapeType = ScrapingType.Paging,
                    ToPage = 4,
                    FromPage = 1

                }
            };
            stepsTemp.Add(GetDocument);

            var navigateToPageLink = new ProcessStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = GetDocument.StepId,
                StepName = "Navigate To Page Link",
                StepType = StepType.ProcessStep,
                ExecuteConfig = new NavigateExecuteConfig
                {
                    CanNavigateByDoc = true,
                    ScrapeType = ScrapingType.WebUrl,
                    Interval = 1000,
                    Description = "navigateToPageLink",
                    HeaderConfigs = new Dictionary<string, string>
                    {
                        { "Cookie", "SERVERID=H; __cfduid=d3de39fbce46c6e4f0207c7ff79bc99ad1544108336; _ga=GA1.3.1314493246.1544108340; _gid=GA1.3.1671812483.1544108340; scs=%7B%22t%22%3A1%7D; sidtb=IAY8ZHzn8vHgNlf242x2X1kELl5edvy4; usidtb=iXDzGkacE9GZchJo09f0H5A3coyzQcXY; ASP.NET_SessionId=admsrwfwy4hk2d14yh4jovgw; __asc=28ff267516784077712e8aca640; __auc=28ff267516784077712e8aca640; ins-mig-done=1; _fbp=fb.2.1544108341321.1813261443; spUID=15441083412080d057358b4.6898a6cc; USER_SEARCH_PRODUCT_CONTEXT=49%7C326%7CSG%7C66%7C8898%7C2656%7C1883%2C18752252; insdrSV=4; current-currency=VND" },
                        { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36" }
                    }
                }
            };
            stepsTemp.Add(navigateToPageLink);

            var GetContainer = new ProcessStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = navigateToPageLink.StepId,
                StepName = "Get Container",
                StepType = StepType.ProcessStep,
                ExecuteConfig = new ExecuteConfig()
                {
                    Pattern = "//div[@class='Main']/div[contains(@class, 'search-productItem')]",
                    ScrapeType = ScrapingType.HTMLDoc,
                }
            };
            stepsTemp.Add(GetContainer);

            var extractProductLink = new ProcessStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = GetContainer.StepId,
                StepName = "extract Product Link",
                StepType = StepType.ProcessStep,
                ExecuteConfig = new HTMLAttributeExecuteConfig()
                {
                    Pattern = "//div[@class='p-title']/h3[1]/a",
                    HtmlAttribute = "href",
                    ScrapeType = ScrapingType.HTMLAttribute,
                    EnclosePrevious = "https://batdongsan.com.vn"
                }
            };
            stepsTemp.Add(extractProductLink);

            var navigateToProductLink = new ProcessStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = extractProductLink.StepId,
                StepName = "navigate To Product Link",
                StepType = StepType.ProcessStep,
                ExecuteConfig = new NavigateExecuteConfig
                {
                    CanNavigateByDoc = true,
                    ScrapeType = ScrapingType.WebUrl,
                    Interval = 1000,
                    Description = "navigateToProductLink",
                    HeaderConfigs = new Dictionary<string, string>
                    {
                        { "Cookie", "SERVERID=H; __cfduid=d3de39fbce46c6e4f0207c7ff79bc99ad1544108336; _ga=GA1.3.1314493246.1544108340; _gid=GA1.3.1671812483.1544108340; scs=%7B%22t%22%3A1%7D; sidtb=IAY8ZHzn8vHgNlf242x2X1kELl5edvy4; usidtb=iXDzGkacE9GZchJo09f0H5A3coyzQcXY; ASP.NET_SessionId=admsrwfwy4hk2d14yh4jovgw; __asc=28ff267516784077712e8aca640; __auc=28ff267516784077712e8aca640; ins-mig-done=1; _fbp=fb.2.1544108341321.1813261443; spUID=15441083412080d057358b4.6898a6cc; USER_SEARCH_PRODUCT_CONTEXT=49%7C326%7CSG%7C66%7C8898%7C2656%7C1883%2C18752252; insdrSV=4; current-currency=VND" },
                        { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36" }
                    }
                }
            };
            stepsTemp.Add(navigateToProductLink);

            var buildData = new StorageStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = navigateToProductLink.StepId,
                StepName = "build Customer Data",
                ExecuteConfig = null,
                StepType = StepType.Storage,
                DataName = "DrawingDataModel"
            };
            stepsTemp.Add(buildData);

            var GetDivInfo = new DataExtractionStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = buildData.StepId,
                StepName = "Get Div Info",
                StepType = StepType.DataExtraction,
                AttributeName = "Data",
                ExecuteConfig = new ExecuteConfig()
                {
                    Pattern = "//div[@class='div-table-cell table2']/div[@class='table-detail']/div[@id='divCustomerInfo']",
                    ScrapeType = ScrapingType.HTMLDoc,
                }
            };
            stepsTemp.Add(GetDivInfo);
            var rootStep = stepsTemp.First(x => x.ParentId == Guid.Empty);
            var json1 = JsonConvert.SerializeObject(stepsTemp);
            AddNextStep(stepsTemp, rootStep);

            return rootStep ;
        }

        public void RunScraping(Dictionary<string, List<Dictionary<string, string>>> data , ScrapingConfigBase config )
        {
            config.SetResponseData(data);
            var json1 = JsonConvert.SerializeObject(config);
            config.Execute();
        }

        public IEnumerable<DrawingDataModel> ConvertData(Dictionary<string, List<Dictionary<string, string>>> data)
        {
            List<Dictionary<string, string>> formatData = null;
            var result = new List<DrawingDataModel>();
            data.TryGetValue(nameof(DrawingDataModel), out formatData);
            if (formatData !=null && formatData.Any())
            {
                result = DataConvertor.ConvertData<DrawingDataModel>(formatData);
            }
             
            return result;
        }

        public ScrapingConfigBase GetExtractCustomerInfoConfig()
        {
            List<ScrapingConfigBase> stepsTemp = new List<ScrapingConfigBase>();
            var   config =  new StorageStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = Guid.Empty,
                StepName = "build Customer Data",
                ExecuteConfig = null,
                StepType = StepType.Storage,
                DataName = "Customer"
            };
            stepsTemp.Add(config);

            var extractCustomerPhoneNumber = new ProcessStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = config.StepId,
                StepName = "Extract Customer PhoneNumber",
                StepType = StepType.ProcessStep,
                ExecuteConfig = new ExecuteConfig
                {
                    Pattern = "//*[@id='LeftMainContent__productDetail_contactMobile']/div[2]",
                    ScrapeType = ScrapingType.HTMLValue
                }
            };
            stepsTemp.Add(extractCustomerPhoneNumber);

            var formatPhoneNumber = new DataExtractionStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = extractCustomerPhoneNumber.StepId,
                StepName = "Format PhoneNumber",
                StepType = StepType.DataExtraction,
                AttributeName = "PhoneNumber",
                ExecuteConfig = new TextExecutorConfig
                {
                    ScrapeType = ScrapingType.Text,
                    TextHandleConfig = new TextReplaceHandleConfig
                    {
                        TextHanldeType = TextHanldeType.Replace,
                        NewValue = "",
                        OldValue = "\r\n"
                    }
                }

            };
            stepsTemp.Add(formatPhoneNumber);

            var extractCustomerName = new ProcessStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = config.StepId,
                StepName = "Extract Customer Name",
                StepType = StepType.ProcessStep,
                ExecuteConfig = new ExecuteConfig
                {
                    Pattern = "//*[@id='LeftMainContent__productDetail_contactName']/div[2]",
                    ScrapeType = ScrapingType.HTMLValue
                }
            };
            stepsTemp.Add(extractCustomerName);

            var formatCustomerName = new DataExtractionStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = extractCustomerName.StepId,
                StepName = "Format Customer Name",
                StepType = StepType.DataExtraction,
                AttributeName = "Name",
                ExecuteConfig = new TextExecutorConfig
                {
                    ScrapeType = ScrapingType.Text,
                    TextHandleConfig = new TextReplaceHandleConfig
                    {
                        TextHanldeType = TextHanldeType.Replace,
                        NewValue = "",
                        OldValue = "\r\n"
                    }
                }

            };
            stepsTemp.Add(formatCustomerName);

            var extractCustomerAddress = new ProcessStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = config.StepId,
                StepName = "Extract Customer Address",
                StepType = StepType.ProcessStep,
                ExecuteConfig = new ExecuteConfig
                {
                    Pattern = "//*[@id='LeftMainContent__productDetail_contactAddress']/div[2]",
                    ScrapeType = ScrapingType.HTMLValue
                }
            };
            stepsTemp.Add(extractCustomerAddress);

            var formatCustomerAddress = new DataExtractionStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = extractCustomerAddress.StepId,
                StepName = "Format Customer Address",
                StepType = StepType.DataExtraction,
                AttributeName = "Address",
                ExecuteConfig = new TextExecutorConfig
                {
                    ScrapeType = ScrapingType.Text,
                    TextHandleConfig = new TextReplaceHandleConfig
                    {
                        TextHanldeType = TextHanldeType.Replace,
                        NewValue = "",
                        OldValue = "\r\n"
                    }
                }

            };
            stepsTemp.Add(formatCustomerAddress);



            var extractCustomerEmail = new DataExtractionStepConfig()
            {
                StepId = Guid.NewGuid(),
                ParentId = config.StepId,
                StepName = "Extract Customer Email",
                StepType = StepType.DataExtraction,
                AttributeName = "Email",
                ExecuteConfig = new ExecuteConfig
                {
                    Pattern = "//*[@id='contactEmail']",
                    ScrapeType = ScrapingType.HTMLDoc
                }
            };
            stepsTemp.Add(extractCustomerEmail);

        
            var rootStep = stepsTemp.First(x => x.ParentId == Guid.Empty);
            var json1 = JsonConvert.SerializeObject(stepsTemp);
            AddNextStep(stepsTemp, rootStep);
            return rootStep;
        }

        public IEnumerable<CustomerModel> ConvertCustomerData(Dictionary<string, List<Dictionary<string, string>>> data)
        {
            List<Dictionary<string, string>> formatData = null;
            var result = new List<CustomerModel>();
            data.TryGetValue("Customer", out formatData);
            if (formatData != null && formatData.Any())
            {
                result = DataConvertor.ConvertData<CustomerModel>(formatData);
            }

            return result;
        }
       
        public List<ScrapingConfigBase> GetScrapingConfigByFile(string configFileName)
        {
            var config = JsonConvert.DeserializeObject<JToken>
                                  (File.ReadAllText($"{BasePath}/{configFileName}"));
            var result = new List<ScrapingConfigBase>();
            List<ScrapingConfigBase> configTempList = new List<ScrapingConfigBase>();
            if (config?.Children() != null && config.Children().Any())
            {
                ScrapingConfigBase step;
                foreach (var item in config.Children())
                {
                    var StepTypeValue = item.SelectToken("StepType").Value<string>();
                    var stepType = (StepType)Enum.Parse(typeof(StepType), StepTypeValue);
                    switch (stepType)
                    {
                        case StepType.ProcessStep:
                            step = new ProcessStepConfig();
                            break;
                        case StepType.DataExtraction:
                            step = new DataExtractionStepConfig();
                            break;
                        case StepType.Storage:
                            step = new StorageStepConfig();
                            break;
                        case StepType.BuildTemp:
                            step = new BuildTempDataStepConfig();
                            break;
                        case StepType.Paging:
                            step = new PagingStepConfig();
                            break;
                        case StepType.WebDriver:
                            step = null;
                            break;
                        default:
                            step = null;
                            break;
                    }
                    step.SetData(item);
                    configTempList.Add(step);
                }
                if (configTempList.Any())
                {
                    var rootSteps = configTempList.Where(x => x.ParentId == Guid.Empty).ToList();
                    foreach (var rootStep in rootSteps)
                    {
                        AddNextStep(configTempList, rootStep);
                        result.Add(rootStep);
                    }
                }
            }
            return result;
        }
        private void AddNextStep(List<ScrapingConfigBase> configList, ScrapingConfigBase step)
        {
            var nextSteps = configList.Where(x => x.ParentId == step.StepId).ToList();
            if (nextSteps.Any())
            {
                foreach (var nextStep in nextSteps)
                {
                    AddNextStep(configList, nextStep);
                    step.Add(nextStep);
                }
            }
        }
    }
}
