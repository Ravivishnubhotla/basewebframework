using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;
using SPS.Bussiness.Wrappers;

namespace SPS.Bussiness.HttpUtils
{
    public class XmlSender
    {
        public static void SendRequest(object request)
        {
            XmlSendTask sendTask = request as XmlSendTask;

            if (sendTask == null)
                throw new AbandonedMutexException(" sendTask is null ");


            try
            {
                bool requestOk = false;

                string errorMessage = string.Empty;

                requestOk = SendRequest(sendTask.SendUrl,sendTask.XmlContent ,3000, sendTask.OkMessage, out errorMessage);

                if (requestOk)
                {
                    //SPRecordWrapper.UpdateXmlSuccessSend(sendTask.RecordID, sendTask.SendDataUrl);
                }
                else
                {
                    //SPRecordWrapper.UpdateXmlFailedSend(sendTask.RecordID, sendTask.SendDataUrl, errorMessage);
                }

            }
            catch (Exception ex)
            {
                //SPRecordWrapper.UpdateXmlFailedSend(sendTask.RecordID, sendTask.SendDataUrl, ex.Message);
            }
        }



        private static bool SendRequest(string requesturl, string xmlPost, int timeOut, string okMessage, out string errorMessage)
        {
            try
            {
                errorMessage = "";

                XmlDocument xmldoc = new XmlDocument();

                xmldoc.LoadXml(xmlPost);

                string encodingName = "UTF-8";

                if (xmldoc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
                {
                    // Get the encoding declaration.
                    XmlDeclaration decl = (XmlDeclaration)xmldoc.FirstChild;
                    // Set the encoding declaration.
                    encodingName = decl.Encoding;

                }

                string responseText = "";

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requesturl);

                webRequest.ContentType = "text/xml";
                webRequest.Method = "POST";

                webRequest.Timeout = timeOut;

                Encoding encoding = Encoding.GetEncoding(encodingName);

                byte[] bytes = encoding.GetBytes(xmlPost);
                webRequest.ContentLength = bytes.Length;
                Stream postData = webRequest.GetRequestStream();
                postData.Write(bytes, 0, bytes.Length);
                postData.Close();

                HttpWebResponse webResponse = null;

                webResponse = (HttpWebResponse)webRequest.GetResponse();


                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);

                    responseText = sr.ReadToEnd();

                    XmlDocument xmlResponse = new XmlDocument();

                    xmlResponse.LoadXml(xmlPost);

                    XmlNode node = xmlResponse.SelectSingleNode("message-result");

                    responseText = node.InnerText;

                    if (node.InnerText == okMessage)
                        return true;

                    return false;

                }
                else
                {
                    errorMessage = "web error Status:" + webResponse.StatusCode.ToString();
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "web error Status:" + ex.Message;
                return false;
            }
        }
    }
}
