using System;
using System.Linq;
using System.Net;
//using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Domain.Stomp;
using WebSocketSharp;
using Stomp.Net;
using Stomp.Net.Stomp.Commands;

namespace ScrobbleBot.Infrastructure.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Represents the <see cref="T:ScrobbleBot.Infrastructure.Services.CommandWebsocketService" /> class.
    /// </summary>
    public class CommandWebsocketService : ICommandWebsocketService
    {
        /// <inheritdoc cref="ICommandWebsocketService.SendCommandAsync(string)"/>
        public void SendCommandAsync(string command, string username)
        {
            Connect(command, username);
        }

        private void Connect(string command, string username)
        {
            using (var ws = new WebSocket("ws://localhost:8080/gs-guide-websocket"))
            {
                ws.OnMessage += ws_OnMessage;
                ws.OnOpen += ws_OnOpen;
                ws.OnError += ws_OnError;
                ws.Connect();
                Thread.Sleep(1000);

                StompMessageSerializer serializer = new StompMessageSerializer();

                var connect = new StompMessage("CONNECT");
                connect["accept-version"] = "1.2";
                connect["host"] = "";
                ws.Send(serializer.Serialize(connect));

                Thread.Sleep(1000);
                var content = new Content() { Username = username, Message = command };
                var broad = new StompMessage("SEND", JsonConvert.SerializeObject(content));
                broad["content-type"] = "application/json";
                broad["destination"] = "/client/message";
                ws.Send(serializer.Serialize(broad));

                Console.ReadKey(true);
            }

        }

        static void ws_OnOpen(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString() + " ws_OnOpen says: " + e.ToString());
        }

        static void ws_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine(DateTime.Now.ToString() + " ws_OnMessage says: " + e.Data);

        }

        static void ws_OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString() + " ws_OnError says: " + e.Message);
        }

        public class Content
        {
            public string Username { get; set; }
            public string Message { get; set; }
        }

    }
}