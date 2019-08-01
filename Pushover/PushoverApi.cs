using System;
using System.Collections.Specialized;
using System.Net;
using System.Xml;
using System.Text;
using System.IO;

namespace Pushover
{
    public class PushoverApi
    {
        private readonly String apiUrl = "https://api.pushover.net/1/messages.xml";
        private readonly String validateUrl = "https://api.pushover.net/1/users/validate.xml";
        private readonly String soundsUrl = "https://api.pushover.net/1/sounds.xml?token=%TOKEN%";

        public String Token { get; set; }

        public PushoverApi()
        {
        }

        public PushoverApi(String token)
        {
            Token = token;
        }

        public bool Send(String user, String message)
        {
            return Send(user, new PushoverMessage(message));
        }

        public bool Send(String user, PushoverMessage message)
        {
            String devices = "";
            for (int i = 0; i < message.Device.Count; i++)
            {
                devices += message.Device[i];
                if (i != message.Device.Count - 1)
                    devices += ",";
            }

            var parameters = new NameValueCollection()
            {
                { "token", Token },
                { "user", user },
                { "title", message.Title },
                { "message", message.Message },
                { "attachment", message.Attachment},
                { "device", devices },
                { "url", message.Url },
                { "url_title", message.UrlTitle },
                { "priority", ((int)message.Priority).ToString()},
                { "sound", message.Sound },
                { "timestamp ", message.Timestamp },
            };

            String response;
            using (var webClient = new WebClient())
            {
                try
                {
                    byte[] responseBytes = webClient.UploadValues(apiUrl, parameters);
                    response = Encoding.Default.GetString(responseBytes);
                }
                catch (WebException e)
                {
                    HttpWebResponse httpresponse = (HttpWebResponse)e.Response;
                    if ((int)httpresponse.StatusCode == 400)
                    {
                        StreamReader responseStreamReader = new StreamReader(e.Response.GetResponseStream());
                        response = responseStreamReader.ReadToEnd();
                    }
                    else
                        throw e;
                }
            }

            XmlDocument document = new XmlDocument();
            document.LoadXml(response);

            String status = document.SelectSingleNode("/response/status").InnerText;
            return status == "1";
        }

        public String[] GetSounds()
        {
            String url = soundsUrl.Replace("%TOKEN%", Token);
            String response;
            using (WebClient webClient = new WebClient())
            {
                response = webClient.DownloadString(url);
            }

            XmlDocument document = new XmlDocument();
            document.LoadXml(response);

            XmlNodeList soundsNodes = document.SelectNodes("/response/sounds/*");

            String[] sounds = new String[soundsNodes.Count];
            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i] = soundsNodes[i].Name;
            }


            return sounds;
        }

        public bool Validate(String user, String device = "")
        {
            var parameters = new NameValueCollection()
            {
                { "token", Token },
                { "user", user },
                { "device", device }
            };

            String response;
            using (var webClient = new WebClient())
            {
                try
                {
                    byte[] responseBytes = webClient.UploadValues(validateUrl, parameters);
                    response = Encoding.Default.GetString(responseBytes);
                }
                catch (WebException e)
                {
                    HttpWebResponse httpresponse = (HttpWebResponse)e.Response;
                    if ((int)httpresponse.StatusCode == 400)
                    {
                        StreamReader responseStreamReader = new StreamReader(e.Response.GetResponseStream());
                        response = responseStreamReader.ReadToEnd();
                    }
                    else
                        throw e;
                }
            }

            XmlDocument document = new XmlDocument();
            document.LoadXml(response);

            String status = document.SelectSingleNode("/response/status").InnerText;
            return status == "1";
        }
    }
}
