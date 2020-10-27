using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO.Requests
{
   public class MessageRequest
    {
        public string UserID { get; set; }
        public string DocID { get; set; }
        public string Message { get; set; }
    
        public MessageRequest(string userId, string docID, string message)
        {
            UserID = userId;
            DocID = docID;
            Message=message;
        }

    }
}
