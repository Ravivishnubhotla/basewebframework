using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using Legendigital.Framework.Common.Utility;

namespace SPS.Bussiness.DataAdapter
{
    public class HttpXmlPostAdapter : IDataAdapter
    {
        private string xmlNodeName;

        public string XmlNodeName
        {
            get { return xmlNodeName; }
            set { xmlNodeName = value; }
        }

        private string xmlString;

        public string XmlString
        {
            get { return xmlString; }
            set { xmlString = value; }
        }

        private Hashtable requestParams;

        private string requestData;

        private string requestIP;

        private string requestFileName;

        private string requestSoucre;

        public string RequestSoucre
        {
            get { return requestSoucre; }
            set { requestSoucre = value; }
        }

        private string requestSoucreParamsString;

        public string RequestSoucreParamsString
        {
            get { return requestSoucreParamsString; }
            set { requestSoucreParamsString = value; }
        }

        public string RequestData
        {
            get { return requestData; }
            set { requestData = value; }
        }

        public string RequestIp
        {
            get { return requestIP; }
            set { requestIP = value; }
        }

        public string RequestFileName
        {
            get { return requestFileName; }
            set { requestFileName = value; }
        }

        public Hashtable RequestParams
        {
            get { return requestParams; }
            set { requestParams = value; }
        }


        public HttpXmlPostAdapter(HttpRequest request, string xmlNodeName)
        {
            this.xmlNodeName = xmlNodeName;

            xmlString = GetXmlPostValueFromRequest(request);

            requestParams = PraseHttpXmlRequestValue(request, xmlString,xmlNodeName);

            requestData = SerializeUtil.ToJson(requestParams);

            requestIP = GetIP(request);

            requestFileName = Path.GetFileNameWithoutExtension(request.PhysicalPath);

            requestSoucre = request.Url.ToString();

            requestSoucreParamsString = request.Url.Query;
        }

        public static string GetIP(HttpRequest request)
        {
            string ip = string.Empty;
            try
            {
                if (request.ServerVariables["HTTP_VIA"] != null)
                {
                    ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
                }
                else
                {
                    ip = request.UserHostAddress;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ip;
        }

        public static Hashtable PraseHttpXmlRequestValue(HttpRequest request, string xml, string xmlNodeName)
        {
            XmlDocument xmldoc = new XmlDocument();

            xmldoc.LoadXml(xml);

            Hashtable hb = new Hashtable();

            XmlNode node = xmldoc.SelectSingleNode(xmlNodeName);

            if (node == null)
                return hb;

            foreach (XmlNode subnode in node.ChildNodes)
            {
                hb.Add(subnode.Name, subnode.InnerText);
            }


            //foreach (string key in request.Params.Keys)
            //{
            //    if (!string.IsNullOrEmpty(key) && !hb.ContainsKey(key.ToLower()))
            //        hb.Add(key.ToLower(), request.Params[key.ToLower()]);
            //}

            return hb;
        }


        public static string GetXmlPostValueFromRequest(HttpRequest request)
        {
            StringBuilder fileContent = new StringBuilder();

            using (StreamReader sr = new StreamReader(request.InputStream, request.ContentEncoding))
            {

                fileContent.Append(sr.ReadToEnd());
                sr.Close();
            }

            return fileContent.ToString();
        }

 


        public bool IsRequestContainValues(string fieldName, string value)
        {
            return requestParams.ContainsKey(fieldName.ToLower()) && requestParams[fieldName.ToLower()].ToString().ToLower().Trim().Contains(value.ToLower().Trim());
        }



        public string GetChannelCode()
        {
            return this.requestFileName.Substring(0, this.requestFileName.Length - ("Xml").Length);
        }
    }
}
