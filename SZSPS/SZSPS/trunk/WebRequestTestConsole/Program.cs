using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Xml;

namespace WebRequestTestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            string requesturl = ConfigurationManager.AppSettings["RequestUrl"];

            int j = 0;

            int testDataCount = int.Parse(ConfigurationManager.AppSettings["testDataCount"]);

            int reTryCount = int.Parse(ConfigurationManager.AppSettings["reTryCount"]);

            int sleepTime = int.Parse(ConfigurationManager.AppSettings["sleepTime"]);

            int timeOut = int.Parse(ConfigurationManager.AppSettings["timeOut"]);

            string okMessage = ConfigurationManager.AppSettings["okMessage"].ToLower();

            string spparams = ConfigurationManager.AppSettings["spparams"].Replace("|","&");


            for (int i = 0; i < testDataCount; i++)
            {
                int retryTimes = 0;

                bool requestOk = false;

                do
                {
                    try
                    {
                        requestOk = SendRequest(i, requesturl + "?" + spparams, timeOut, okMessage);
                    }
                    catch
                    {
                        requestOk = false;
                    }

                    retryTimes++;

                    if (retryTimes >= reTryCount)
                        break;

                } while (!requestOk);


                if (!requestOk)
                {
                    j++;
                    Console.WriteLine(string.Format("line {0} failed", i));
                }
                else
                {
                    Console.WriteLine(string.Format("line {0} ok", i));               
                }

                Thread.Sleep(sleepTime);

            }

            Console.WriteLine("Error Count:" + j.ToString());

            Console.ReadKey();

        }

        private static bool SendRequest(int i, string requesturl, int timeOut, string okMessage)
        {
            Console.WriteLine(string.Format(requesturl, i));

            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(string.Format(requesturl,i));

            webRequest.Timeout = timeOut;

            HttpWebResponse webResponse = null;

            webResponse = (HttpWebResponse)webRequest.GetResponse();


            if (webResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);
                string responseText = sr.ReadToEnd();

                return responseText.Trim().ToLower().Equals(okMessage);
            }

            return false;
        }


         public static string PostXMLTransaction(string v_strURL, string xml)
    {
        //Declare XMLResponse document
        string XMLResponse = null;

        //Declare an HTTP-specific implementation of the WebRequest class.
        HttpWebRequest objHttpWebRequest;

        //Declare an HTTP-specific implementation of the WebResponse class
        HttpWebResponse objHttpWebResponse = null;

        //Declare a generic view of a sequence of bytes
        Stream objRequestStream = null;
        Stream objResponseStream = null;

        //Declare XMLReader
        XmlTextReader objXMLReader;

        //Creates an HttpWebRequest for the specified URL.
        objHttpWebRequest = (HttpWebRequest)WebRequest.Create(v_strURL);

        try
        {
            //---------- Start HttpRequest 

            //Set HttpWebRequest properties
            byte[] bytes;
            bytes = System.Text.Encoding.ASCII.GetBytes(xml);
            objHttpWebRequest.Method = "POST";
            objHttpWebRequest.ContentLength = bytes.Length;
            objHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";

            //Get Stream object 
            objRequestStream = objHttpWebRequest.GetRequestStream();

            //Writes a sequence of bytes to the current stream 
            objRequestStream.Write(bytes, 0, bytes.Length);

            //Close stream
            objRequestStream.Close();

            //---------- End HttpRequest

            //Sends the HttpWebRequest, and waits for a response.
            objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();

            //---------- Start HttpResponse
            if (objHttpWebResponse.StatusCode == HttpStatusCode.OK)
            {
                //Get response stream 
                    StreamReader sr = new StreamReader(objHttpWebResponse.GetResponseStream(), Encoding.Default);

                    XMLResponse = sr.ReadToEnd();

 
 

 
            }

            //Close HttpWebResponse
            objHttpWebResponse.Close();
        }
        catch (WebException we)
        {
            //TODO: Add custom exception handling
            throw new Exception(we.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            //Close connections
            objRequestStream.Close();
            objResponseStream.Close();
            objHttpWebResponse.Close();

            //Release objects
            objXMLReader = null;
            objRequestStream = null;
            objResponseStream = null;
            objHttpWebResponse = null;
            objHttpWebRequest = null;
        }

        //Return
        return XMLResponse;
    }

        //private static bool SendRequest(int i, string requesturl)
        //{

        //}


        //private static string BulidUrl(int i, string requesturl, string mobileformat, string msg, string ywid)
        //{
        //    NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

        //    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["cpid"]))
        //        BulidParams(queryString, ConfigurationManager.AppSettings["cpid"], "1");
        //    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["mid"]))
        //        BulidParams(queryString, ConfigurationManager.AppSettings["mid"], "2");
        //    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["mobile"]))
        //        BulidParams(queryString, ConfigurationManager.AppSettings["mobile"],string.Format(mobileformat,i.ToString("D5")));
        //    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["port"]))
        //        BulidParams(queryString, ConfigurationManager.AppSettings["port"], "21");
        //    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ywid"]))
        //        BulidParams(queryString, ConfigurationManager.AppSettings["ywid"], ywid);
        //    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["msg"]))
        //        BulidParams(queryString, ConfigurationManager.AppSettings["msg"], string.Format(msg,i.ToString("D5")));

        //    string exparams = ConfigurationManager.AppSettings["exparams"];

        //    string[] ep = exparams.Split(',');

        //    foreach (string s in ep)
        //    {
        //        BulidParams(queryString, s, s + i.ToString("D5"));               
        //    }

        //    return string.Format("{0}?{1}", requesturl, queryString.ToString());
        //}

        //private static void BulidParams(NameValueCollection queryString, string key, string value)
        //{
        //    queryString.Add(key, HttpUtility.UrlEncode(value));
        //}
    }
}
