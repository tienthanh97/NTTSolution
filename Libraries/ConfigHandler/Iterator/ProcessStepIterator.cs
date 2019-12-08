namespace NTT.ScrapingLib.ConfigHandler.Iterator
{
    using System.Collections;
    using System.Collections.Generic;
    public class ProcessStepIterator : IEnumerator
    {
         private List<ScrapingConfigBase> _scrapingConfigs;

        private int location = 0;
        public ProcessStepIterator(List<ScrapingConfigBase> scrapingConfigs)
        {
            _scrapingConfigs = scrapingConfigs;
        }

        public object Current
        {
            get
            {
                return _scrapingConfigs[location++];
            }
        }
        public bool MoveNext()
        {
            if (location < _scrapingConfigs.Count && _scrapingConfigs[location] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            location = 0;
        }
    }
}
