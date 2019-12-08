using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.ScrapingLib.TypeHelper
{
    public class PropertyHelper
    {
        public object Get<T>(T inputData,string propertyName)
        {
            // Type myType = typeof(T);
            var propertiesInfo = inputData.GetType().GetProperty(propertyName);

            return propertiesInfo.GetValue(inputData, null);
        }
    }
}
