using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Exceptions
{
    public static class NhibernateMembershipProviderExceptionUtil
    {
        public static string FormatExceptionMessage(string message)
        {
            return FormatExceptionMessage("NHibernateProvider", message);
        }

        public static string FormatExceptionMessage(object source, string message)
        {
            return FormatExceptionMessage(source.GetType(), message);
        }

        public static string FormatExceptionMessage(string message, Exception ex)
        {
            return FormatExceptionMessage("NHibernateProvider", message, ex);
        }

        public static string FormatExceptionMessage(string className, string message)
        {
            return FormatExceptionMessage(className, message, null);
        }

        public static string FormatExceptionMessage(Type type, string message)
        {
            return FormatExceptionMessage(type.Name, message);
        }

        public static string FormatExceptionMessage(object source, string message, Exception ex)
        {
            return FormatExceptionMessage(source.GetType(), message, ex);
        }

        public static string FormatExceptionMessage(string className, string message, Exception ex)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("<br><br>{0}: ", className);
            builder.Append(message);
            if (ex != null)
            {
                builder.AppendFormat("; operation failed with error \"{0}\".<br><br>", ex.Message);
                builder.AppendFormat("<i>Base Exception Message</i>: \"{0}\"<br><br>", ex.GetBaseException().Message);
                builder.AppendFormat("<i>Base Exception Stack Trace</i>: {0}", ex.GetBaseException().StackTrace);
            }
            return builder.ToString();
        }

        public static string FormatExceptionMessage(Type type, string message, Exception ex)
        {
            return FormatExceptionMessage(type.Name, message, ex);
        }

        public static ProviderException NewProviderException(string message)
        {
            return new ProviderException(FormatExceptionMessage(message));
        }

        public static ProviderException NewProviderException(object source, string message)
        {
            return new ProviderException(FormatExceptionMessage(source, message));
        }

        public static ProviderException NewProviderException(string message, Exception ex)
        {
            return new ProviderException(FormatExceptionMessage(message, ex));
        }

        public static ProviderException NewProviderException(object source, string message, Exception ex)
        {
            return new ProviderException(FormatExceptionMessage(source, message, ex));
        }
    }
}
