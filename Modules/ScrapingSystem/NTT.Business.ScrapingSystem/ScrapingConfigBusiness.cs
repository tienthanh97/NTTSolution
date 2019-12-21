using NTT.Contract.ScrapingSystem;
using NTT.Data.EntityModel.ScrapingSytemEntity;
using NTT.Data.Repositories;
using NTT.Model.ScrapingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTT.Business.ScrapingSystem
{
    public class ScrapingConfigBusiness : IScrapingConfigBusiness
    {
        private readonly IRepository<ScrapingConfig> _scrapingConfigRepository;
        public ScrapingConfigBusiness(IRepository<ScrapingConfig> scrapingConfigRepository)
        {
            this._scrapingConfigRepository = scrapingConfigRepository;
        }
        public List<ScrapingConfigModel> GetScrapingConfigInfo()
        {
            var scrapingconfig = this._scrapingConfigRepository.Table.Select(s => new ScrapingConfigModel
            {
                Id = s.Id,
                ConfigData = s.ConfigData,
                Business = s.Business,
                QueueKey = s.QueueKey,
                StorageAddress = s.StorageAddress,
                CreateDate = s.CreateDate.Value
            }).ToList();
            return scrapingconfig;


        }
    }
}
