using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using log4net.Appender;
using log4net.Core;

namespace Legendigital.Common.Web.AppClass
{
    public class SmtpClientSmtpAppender : SmtpAppender
    {

        override protected void SendBuffer(LoggingEvent[] events)
        {

            try
            {

                StringWriter writer = new StringWriter(System.Globalization.CultureInfo.InvariantCulture);

                string t = Layout.Header;

                if (t != null)
                {

                    writer.Write(t);

                }

                for (int i = 0; i < events.Length; i++)
                {

                    // Render the event and append the text to the buffer

                    RenderLoggingEvent(writer, events[i]);

                }

                t = Layout.Footer;

                if (t != null)
                {

                    writer.Write(t);

                }

                // Use SmtpClient so we can use SSL.

                SmtpClient client = new SmtpClient(SmtpHost, Port);

                //client.EnableSsl = true;

                client.Credentials = new NetworkCredential(Username, Password);

                string messageText = writer.ToString();

                MailMessage mail = new MailMessage(From, To, Subject, messageText);

                client.Send(mail);

            }

            catch (Exception e)
            {
                
            }

        }
    }

}
