using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Data.EntityModel.ScrapingSytemEntity
{
    public class ScrapingConfig : BaseEntity
    {
        public string ConfigData { get; set; }

        public long Business { get; set; }

        public string QueueKey { get; set; }

        public string StorageAddress { get; set; }

    }
}
