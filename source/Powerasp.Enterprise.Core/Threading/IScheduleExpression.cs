using System;

namespace Powerasp.Enterprise.Core.Threading
{
    public interface IScheduleExpression
    {
        bool CanInvoke(DateTime now);

        bool Once { get; }
    }
}