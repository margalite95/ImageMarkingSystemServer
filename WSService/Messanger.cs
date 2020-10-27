using DIContract;
using ImageMarkingContract.Interface;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WSService
{
    [Register(Policy.Singelton, typeof(IMessanger))]
    public class Messanger: IMessanger
    {
        Dictionary<string, Dictionary<string, IReceiver>> _sockets;
        public Messanger()
        {
            _sockets = new Dictionary<string, Dictionary<string, IReceiver>>();
        }
        public async Task Send(string id, string docId, string message)
        {

            if (_sockets.ContainsKey(docId))
            {
                foreach (var user in _sockets[docId])
                {
                    var buffer = Encoding.UTF8.GetBytes(id + "/" + message);
                    await user.Value._webSocket.SendAsync(new ReadOnlyMemory<byte>(buffer), WebSocketMessageType.Text
                        , true
                       , CancellationToken.None);
                }
            }
        }
        public IReceiver Add(string id, string docId, WebSocket socket)
        {
            IReceiver retval = null;

            if (!_sockets.ContainsKey(docId)) //if docid not exsit enter 
            {
                _sockets[docId] = new Dictionary<string, IReceiver>();
                retval = new Receiver(socket,this,id,docId);
                _sockets[docId].Add(id, retval);

            }
            else
            {
                if (!_sockets[docId].ContainsKey(id)) //if docid already exsit but userid not exist enter
                {
                    retval = new Receiver(socket,this,id,docId);
                    _sockets[docId].Add(id, retval);
                }
            }
            return retval;
        }
        public IEnumerable<string> GetReciversDocs(string docId)
        {
            return _sockets[docId].Keys;
        }

        public void ConnectionClose(string receiverId, string docId)
        {
           
            _sockets[docId].Remove(receiverId);

            Send(receiverId, docId, "disconnect");
        }
    }
}
