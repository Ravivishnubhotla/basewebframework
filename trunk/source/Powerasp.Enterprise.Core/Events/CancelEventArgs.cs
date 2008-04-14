using System;

namespace Powerasp.Enterprise.Core.Events
{
    public class CancelEventArgs : EventArgs
    {
        private bool _cancel;

        public CancelEventArgs() : this(false)
        {
        }

        public CancelEventArgs(bool cancel)
        {
            this._cancel = cancel;
        }

        public bool Cancel
        {
            get
            {
                return this._cancel;
            }
            set
            {
                this._cancel = value;
            }
        }
    }
}