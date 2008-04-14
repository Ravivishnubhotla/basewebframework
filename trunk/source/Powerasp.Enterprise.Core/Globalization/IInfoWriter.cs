using System;
using System.Globalization;
using Powerasp.Enterprise.Core.Globalization;

namespace Powerasp.Enterprise.Core.Globalization
{
    public interface IInfoWriter : IDisposable
    {
        void Close();
        void Write(string key, string value, CultureInfo cultureInfo);
        void WriteItem(string key, IInfoItem item, CultureInfo cultureInfo);

        bool IsClosed { get; }
    }
}