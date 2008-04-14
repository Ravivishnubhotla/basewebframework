using System;
using System.Globalization;

namespace Powerasp.Enterprise.Core.Globalization
{
    public interface IInfoReader : IDisposable
    {
        void Close();
        CultureInfo GetCultureInfo();
        string GetKey();
        object GetObject();
        bool Read();

        bool IsClosed { get; }

        bool IsItem { get; }
    }
}