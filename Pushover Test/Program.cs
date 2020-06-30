using System;
using Pushover;

namespace Pushover_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            PushoverClient api = new PushoverClient("token");

            PushoverMessage message = new PushoverMessage()
            {
                Title = "title",
                Message = "message",
                Priority = Priority.High,
                Sound = "magic",
                Url = "https://www.github.com",
                UrlTitle = "Github",
            };

            bool result = api.Send("token", message);
            Console.Read();
        }
    }
}
