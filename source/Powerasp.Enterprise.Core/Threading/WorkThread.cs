using System;
using System.Threading;

namespace Powerasp.Enterprise.Core.Threading
{
    public class WorkThread
    {
        public static void QueueItem(WaitCallback callBack)
        {
            QueueItem(callBack, null);
        }

        public static void QueueItem(WaitCallback callBack, object state)
        {
            int num;
            int num2;
            if (callBack == null)
            {
                throw new ArgumentNullException("callBack");
            }
            ThreadPool.GetAvailableThreads(out num, out num2);
            if (num <= 0)
            {
                throw new Exception("Thread pool is full.");
            }
            if (state == null)
            {
                ThreadPool.QueueUserWorkItem(callBack);
            }
            else
            {
                ThreadPool.QueueUserWorkItem(callBack, state);
            }
        }
    }
}