using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using Powerasp.Enterprise.Core.Security.Cryptography;
using Powerasp.Enterprise.Core.Text;
using Powerasp.Enterprise.Core.Utility;

namespace Powerasp.Enterprise.Core.Security.Authorization
{
    public class DigestCredential : NamePasswordCredential
    {
        private string _summary;

        public DigestCredential(string name, string password, string summary) : base(name, password)
        {
            this._summary = summary;
        }

        protected static string HashCredentials(IDictionary requestInfo, DigestCredential credential)
        {
            string str5;
            if (requestInfo == null)
            {
                throw new ArgumentNullException("requestInfo");
            }
            string s = string.Format("{0}:{1}:{2}", credential.Name, requestInfo["realm"], credential.Password);
            string str2 = string.Format("AUTHENTICATE:{1}", requestInfo.Contains("uri") ? requestInfo["uri"].ToString() : string.Empty);
            MD5Generator generator = new MD5Generator();
            generator.Initialize();
            generator.Update(Encoding.ASCII.GetBytes(s));
            byte[] hash = generator.Hash;
            s = string.Format("{0}:{1}", requestInfo["nonce"], requestInfo["cnonce"]);
            generator.Initialize();
            generator.Update(hash);
            generator.Update(Encoding.ASCII.GetBytes(s));
            string str3 = StringUtil.BytesToHex(generator.Hash);
            generator.Initialize();
            generator.Update(Encoding.ASCII.GetBytes(str2));
            string str4 = StringUtil.BytesToHex(generator.Hash);
            if (requestInfo.Contains("qop"))
            {
                str5 = string.Format("{0}:{1}:{2}:{3}:{4}:{5}", new object[] { str3, requestInfo["nonce"], requestInfo["nc"], requestInfo["cnonce"], requestInfo["qop"], str4 });
            }
            else
            {
                str5 = string.Format("{0}:{1}:{2}", str3, requestInfo["nonce"], str4);
            }
            generator.Initialize();
            generator.Update(Encoding.ASCII.GetBytes(str5));
            return StringUtil.BytesToHex(generator.Hash);
        }

        protected static string HashedDigest(IDictionary requestInfo, DigestCredential credential, string hashedDigest)
        {
            if (requestInfo == null)
            {
                throw new ArgumentNullException("requestInfo");
            }
            if (credential == null)
            {
                throw new ArgumentNullException("credential");
            }
            if (hashedDigest == null)
            {
                throw new ArgumentNullException("hashedDigest");
            }
            StringBuilder builder = new StringBuilder();
            if (requestInfo.Contains("charset"))
            {
                builder.AppendFormat("charset=\"{0}\",", requestInfo["charset"]);
            }
            builder.AppendFormat("username=\"{0}\",", credential.Name);
            if (requestInfo.Contains("realm"))
            {
                builder.AppendFormat("realm=\"{0}\",", requestInfo["realm"]);
            }
            if (requestInfo.Contains("qop"))
            {
                builder.AppendFormat("nonce=\"{0}\",", requestInfo["nonce"]);
                builder.AppendFormat("nc=\"{0}\",", requestInfo["nc"]);
                builder.AppendFormat("cnonce=\"{0}\",", requestInfo["cnonce"]);
                if (requestInfo.Contains("uri"))
                {
                    builder.AppendFormat("digest-uri=\"{0}\",", requestInfo["uri"]);
                }
                builder.AppendFormat("response=\"{0}\",", hashedDigest);
                builder.AppendFormat("qop=\"{0}\"", requestInfo["qop"]);
            }
            else
            {
                builder.AppendFormat("nonce=\"{0}\",", requestInfo["nonce"]);
                builder.AppendFormat("response=\"{0}\"", hashedDigest);
            }
            Base64 base2 = new Base64();
            base2.Encoding = Encoding.ASCII;
            return base2.Encode(builder.ToString());
        }

        protected static IDictionary ParseCredentials(DigestCredential credential)
        {
            if (credential == null)
            {
                throw new ArgumentNullException("credential");
            }
            IDictionary dictionary = new ListDictionary();
            string[] strArray = credential.Summary.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].IndexOf("=") == -1)
                {
                    dictionary.Add(strArray[i].ToLower(), string.Empty);
                }
                else
                {
                    string[] strArray2 = strArray[i].Split(new char[] { '=' }, 2);
                    dictionary.Add(strArray2[0].Trim(new char[] { ' ', '"' }).ToLower(), strArray2[1].Trim(new char[] { ' ', '"' }));
                }
            }
            if (!dictionary.Contains("realm"))
            {
                dictionary.Add("realm", string.Empty);
            }
            if (!dictionary.Contains("nonce"))
            {
                dictionary.Add("nonce", string.Empty);
            }
            if (!dictionary.Contains("cnonce"))
            {
                dictionary.Add("cnonce", string.Empty);
            }
            if (!dictionary.Contains("nc"))
            {
                dictionary.Add("00000001", string.Empty);
            }
            return dictionary;
        }

        public string Hash
        {
            get
            {
                IDictionary requestInfo = ParseCredentials(this);
                string hashedDigest = HashCredentials(requestInfo, this);
                return HashedDigest(requestInfo, this, hashedDigest);
            }
        }

        public string Summary
        {
            get
            {
                return this._summary;
            }
        }
    }
}