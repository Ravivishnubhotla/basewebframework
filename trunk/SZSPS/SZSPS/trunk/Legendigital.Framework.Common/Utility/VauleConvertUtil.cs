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
    }
}
