using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Utility
{
    public static class ValueConvertUtil
    {
        public static T ConvertNullableValue<T>(T? convertVlaue,T defaultValue) where T : struct 
        {
            return convertVlaue.HasValue ? convertVlaue.Value : defaultValue;
        }
        public static T ConvertNullableValue<T>(T? convertVlaue) where T : struct
        {
            return ConvertNullableValue<T>(convertVlaue,default(T));
        }
        public static string ConvertStringValue(string convertVlaue, string defaultValue) 
        {
            if (convertVlaue == null)
                return defaultValue;
            return convertVlaue;
        }
        public static string ConvertStringValue(string convertVlaue) 
        {
            return ConvertStringValue(convertVlaue,string.Empty);
        }


    }
}
