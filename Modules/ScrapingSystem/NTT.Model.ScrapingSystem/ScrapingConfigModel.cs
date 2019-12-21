using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Model.ScrapingSystem
{
    public class ScrapingConfigModel
    {
        public long Id { get; set; }
        public string ConfigData { get; set; }

        public long Business { get; set; }

        public string QueueKey { get; set; }

        public string StorageAddress { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
