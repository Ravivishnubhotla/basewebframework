using System;

namespace Powerasp.Enterprise.Core.Text
{
    public abstract class EncodeBase : IEncode
    {
        private System.Text.Encoding _encoding;

        protected EncodeBase() : this(GlobalEncodingSelection.Select)
        {
        }

        protected EncodeBase(System.Text.Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }
            this._encoding = encoding;
        }

        public string Decode(string s)
        {
            return this.Decode(s, this.Encoding);
        }

        public abstract string Decode(string s, System.Text.Encoding encoding);
        public string Encode(string s)
        {
            return this.Encode(s, this.Encoding);
        }

        public abstract string Encode(string s, System.Text.Encoding encoding);

        public System.Text.Encoding Encoding
        {
            get
            {
                return this._encoding;
            }
            set
            {
                this._encoding = value;
            }
        }
    }
}