using System.Collections;

namespace NTT.ScrapingLib.ConfigHandler.Iterator
{
    public class DataExtractionStepIterator : IEnumerator
    {
        #region variable

        private ScrapingConfigBase _stepConfig;

        #endregion

        #region Properties

        public object Current
        {
            get
            {
                return _stepConfig;
            }
        }

        #endregion

        #region Constructor

        public DataExtractionStepIterator(ScrapingConfigBase stepConfig)
        {
            _stepConfig = stepConfig;
        }

        #endregion

        #region Methods

        public bool MoveNext()
        {
            return false;
        }

        public void Reset()
        {
        }

        #endregion
    }
}
