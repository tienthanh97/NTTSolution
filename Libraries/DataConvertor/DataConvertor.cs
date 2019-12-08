using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NTT.ScrapingLib.DataConvertor
{
    public static class DataConvertor
    {
        public static List<T> ConvertData<T>(List<Dictionary<string, string>> data)
        {
            var result = new List<T>();
            foreach (var dataItem in data)
            {
                // Create T instance for add into List result
                var model = (T)Activator.CreateInstance(typeof(T));
                foreach (var dicItem in dataItem)
                {
                    // Pass data for model
                    ModelHelper.SetValueGeneric<T>(model, dicItem.Key, dicItem.Value);
                }
                result.Add(model);
            }
            return result;
        }

        private static Type GetModelByName(string name)
        {
            var model = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type =>
             type.BaseType == typeof(ConvertBase) && type.Name.Equals(name) );
            if (model != null)
            {
                return model;
            }
            else
            {
                return null;
            }
        }



    }
}
