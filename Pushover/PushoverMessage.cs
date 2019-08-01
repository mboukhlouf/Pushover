using System;
using System.Collections.Generic;
using System.Text;

namespace Pushover
{
    public class PushoverMessage
    {
        /// <summary>
        /// The message's title, otherwise the app's name is used
        /// </summary>
        public String Title { get; set; } = null;

        /// <summary>
        /// The message
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        ///  An image attachment to send with the message
        /// </summary>
        public String Attachment { get; set; }

        /// <summary>
        /// The list of devices
        /// </summary>
        public List<String> Device { get; } = new List<String>();

        /// <summary>
        /// A supplementary URL to show with the message
        /// </summary>
        public String Url { get; set; } = null;

        /// <summary>
        /// A title for the supplementary URL, otherwise just the URL is shown
        /// </summary>
        public String UrlTitle { get; set; } = null;

        /// <summary>
        /// The priority of the message
        /// </summary>
        public Priority Priority { get; set; } = Priority.Normal;

        /// <summary>
        /// The name of the sound to use with 
        /// </summary>
        public String Sound { get; set; } = "pushover";

        /// <summary>
        /// A Unix timestamp of the message's date and time to display to the user, rather than the time the message is received by the Pushover Api
        /// </summary>
        public String Timestamp { get; set; } = null;

        public PushoverMessage()
        {
        }

        public PushoverMessage(String message)
        {
            Message = message;
        }
    }
}
