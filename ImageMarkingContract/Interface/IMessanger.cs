using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ImageMarkingContract.Interface
{
   public interface IMessanger
    {
        IReceiver Add(string id, string docId, WebSocket socket);
        Task Send(string userId, string docId, string message);
        IEnumerable<string> GetReciversDocs(string docId);
        void ConnectionClose(string receiverId, string docId);
    }
}
