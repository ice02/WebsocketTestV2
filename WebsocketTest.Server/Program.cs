using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebsocketTest.Server
{
    class Program
    {
        public class Toolbox : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                var msg = e.Data == "Version"
                          ? "1.0.0"
                          : "0";

                Send(msg);
            }

            protected override void OnOpen()
            {
                base.OnOpen();

                Console.WriteLine("Opening");
            }

            protected override void OnError(ErrorEventArgs e)
            {
                base.OnError(e);

                Console.WriteLine($"Error : {e.Message}");
            }
        }


        static void Main(string[] args)

        {

            //var wssv = new WebSocketServer(5055, true);
            var wssv = new WebSocketServer("ws://localhost:8888");
            wssv.AddWebSocketService<Toolbox>("/Toolbox");

            //wssv.SslConfiguration.ServerCertificateValidationCallback =
            //    (sender, certificate, chain, sslPolicyErrors) => {
            //    // Do something to validate the server certificate.
            //    ...

            //    return true; // If the server certificate is valid.
            //};

            wssv.Log.Level = LogLevel.Trace;

            wssv.Start();
            Console.ReadKey(true);
            wssv.Stop();

            //RunAsync().Wait();


        }
    }
}

