using NTT.Model.ScrapingSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Contract.ScrapingSystem
{
    public interface IScrapingConfigBusiness
    {
        List<ScrapingConfigModel> GetScrapingConfigInfo();
    }
}
