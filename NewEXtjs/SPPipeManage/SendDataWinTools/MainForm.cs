using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SendDataWinTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSender_Click(object sender, EventArgs e)
        {
            this.txtResult.Text = PostXMLTransaction(this.txtUrl.Text.Trim(), this.txtSendText.Text.Trim());
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
                objHttpWebResponse.Close();

 

            }

            //Return
            return XMLResponse;
        }
    }
}
