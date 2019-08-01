using System;
using Pushover;

namespace Pushover_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            PushoverApi api = new PushoverApi("tokey");
            bool result =  api.Send("u17yyoz2uotorj2nitzpyqp2dpbt92", "hello world");
        }
    }
}
