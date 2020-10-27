using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO
{
   public class GetSharedDocumentsResponseOK: GetSharedDocumentsResponse
    {
        public string DocID { get; set; }
        public string UserID { get; set; }
        public GetSharedDocumentsResponseOK(string docID, string userID)
        {
            DocID = docID;
            UserID = userID;
        }
    }
}
