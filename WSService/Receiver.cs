
using ImageMarkingContract.DTO.Requests;
using ImageMarkingContract.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WSService
{
    public class Receiver:IReceiver
    {
        Task _recTask;
        IMessanger _messanger;
        public string ReceiverId { get; set; }
        public string DocId { get; set; }
        public WebSocket _webSocket { get; set; }

        public Receiver(WebSocket webSocket, IMessanger messanger, string receiverId,string docId)
        {
            _webSocket = webSocket;
            _messanger = messanger;
            ReceiverId = receiverId;
            DocId = docId;
        }
        public async Task Start()
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            Console.WriteLine(result);
            while (!result.CloseStatus.HasValue)
            {
                await _webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await _webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            _messanger.ConnectionClose(ReceiverId,DocId);


        }

    }
}
