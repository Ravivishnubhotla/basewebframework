using System;
using System.Text;
using Powerasp.Enterprise.Core.Security.Authorization;

namespace Powerasp.Enterprise.Core.Security.Authorization
{
    public class NamePasswordCredential : ICredential
    {
        private string _name;
        private byte[] _password;

        public NamePasswordCredential(string name, string password) : this(name, Encoding.Unicode.GetBytes(password))
        {
        }

        public NamePasswordCredential(string name, byte[] password)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            this._name = name;
            this._password = password;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public string Password
        {
            get
            {
                return Encoding.Unicode.GetString(this._password);
            }
        }

        public byte[] PasswordBytes
        {
            get
            {
                return this._password;
            }
        }
    }
}