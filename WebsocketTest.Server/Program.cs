using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
//using SuperSocket;
//using SuperSocket.ProtoBase;
//using SuperSocket.Server;

namespace WebsocketTest.Server
{
    class Program
    {
        //static SuperSocketServer CreateSocketServer<TPackageInfo, TPipelineFilter>(Dictionary<string, string> configDict = null, Func<IAppSession, TPackageInfo, Task> packageHandler = null)
        //    where TPackageInfo : class
        //    where TPipelineFilter : IPipelineFilter<TPackageInfo>, new()

        //{

        //    if (configDict == null)

        //    {

        //        configDict = new Dictionary<string, string>

        //        {

        //            { "serverOptions:name", "TestServer" },

        //            { "serverOptions:listeners:0:ip", "Any" },

        //            { "serverOptions:listeners:0:port", "4040" }

        //        };

        //    }



        //    var server = new SuperSocketServer();



        //    var services = new ServiceCollection();



        //    var builder = new ConfigurationBuilder().AddInMemoryCollection(configDict);

        //    var config = builder.Build();



        //    services.AddLogging(loggingBuilder => loggingBuilder.AddConsole());



        //    var serverOptions = new ServerOptions();

        //    config.GetSection("serverOptions").Bind(serverOptions);



        //    server.Configure<TPackageInfo, TPipelineFilter>(serverOptions, services, packageHandler: packageHandler);



        //    return server;

        //}

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

            wssv.Start();
            Console.ReadKey(true);
            wssv.Stop();

            //RunAsync().Wait();


        }



        //static async Task RunAsync()

        //{

        //    var server = CreateSocketServer<TextPackageInfo, LinePipelineFilter>(packageHandler: async (s, p) =>

        //    {

        //        await s.Channel.SendAsync(Encoding.UTF8.GetBytes(p.Text).AsMemory());

        //    });



        //    await server.StartAsync();



        //    Console.WriteLine("The server is started.");



        //    while (Console.ReadLine().ToLower() != "c")

        //    {

        //        continue;

        //    }



        //    await server.StopAsync();

        //}

    }
}

