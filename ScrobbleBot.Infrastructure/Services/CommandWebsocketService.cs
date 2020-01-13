using System;
using Newtonsoft.Json;
using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Domain.Stomp;
using WebSocketSharp;

namespace ScrobbleBot.Infrastructure.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Represents the <see cref="T:ScrobbleBot.Infrastructure.Services.CommandWebsocketService" /> class.
    /// </summary>
    public class CommandWebsocketService : ICommandWebsocketService
    {
        /// <inheritdoc cref="ICommandWebsocketService.SendCommandAsync(string, string)"/>
        public void SendCommandAsync(string command, string username)
        {
            Connect(command, username);
        }

        private void Connect(string command, string username)
        {
            using (var ws = new WebSocket("ws://127.0.0.1:8080/gs-guide-websocket"))
            {
                ws.OnMessage += ws_OnMessage;
                ws.OnOpen += ws_OnOpen;
                ws.Connect();

                StompMessageSerializer serializer = new StompMessageSerializer();

                var connect = new StompMessage("CONNECT");
                connect["accept-version"] = "1.2";
                connect["host"] = "";
                ws.Send(serializer.Serialize(connect));

                var content = new Content() { Username = username, Message = command, id = Guid.NewGuid() };
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
            public Guid id { get; set; }
            public string Username { get; set; }
            public string Message { get; set; }
        }

    }
}