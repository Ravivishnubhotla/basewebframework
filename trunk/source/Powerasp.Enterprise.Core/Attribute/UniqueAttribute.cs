using System;

namespace Powerasp.Enterprise.Core.Attribute
{
    public class UniqueAttribute : System.Attribute
    {
        private Guid _uniquity;

        public UniqueAttribute(Guid g)
        {
            this._uniquity = Guid.Empty;
            this._uniquity = g;
        }

        public UniqueAttribute(string s)
        {
            this._uniquity = Guid.Empty;
            this._uniquity = new Guid(s);
        }

        public override string ToString()
        {
            return this._uniquity.ToString();
        }

        public string Token
        {
            get
            {
                return this._uniquity.ToString();
            }
        }
    }
}