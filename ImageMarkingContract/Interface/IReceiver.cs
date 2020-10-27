using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ImageMarkingContract.Interface
{
   public interface IReceiver
    {
        public WebSocket _webSocket { get; set; }
        public Task Start();
    }
}
