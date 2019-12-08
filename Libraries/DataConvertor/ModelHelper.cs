using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NTT.ScrapingLib.DataConvertor
{
    public static class ModelHelper
    {
        /// <summary>
        /// Set Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T SetValueGeneric<T>(T model , string fileName,object value )
        {
            Type type = model.GetType();
            PropertyInfo field = type.GetProperty(fileName);
            if (field!=null)
            {
                field.SetValue(model, value);
            }
            return model;
        }

        public static object SetValue(object model, string fileName, object value)
        {
            Type type = model.GetType();
            PropertyInfo field = type.GetProperty(fileName);
            if (field != null)
            {
                field.SetValue(model, value);
            }
            return model;
        }

        /// <summary>
        /// Get Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static object GetValueGeneric<T>(T model, string fieldName)
        {
            Type type = model.GetType();
            PropertyInfo field = type.GetProperty(fieldName);
            if (field != null)
            {
                return field.GetValue(model);
            }
            return null;
        }

        /// <summary>
        /// Get String Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string GetStringValueGeneric<T>(T model,string fieldName)
        {
            Type type = model.GetType();
            PropertyInfo field = type.GetProperty(fieldName);
            if (field != null)
            {
                var value = field.GetValue(model);
                if (value ==null && string.IsNullOrEmpty(value.ToString()))
                {
                    return string.Empty;
                    
                }
                else
                {
                    return value.ToString();
                }
              
               
            }
            return string.Empty;
        }
    }
}
