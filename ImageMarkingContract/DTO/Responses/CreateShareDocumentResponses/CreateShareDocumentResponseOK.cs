using System;


namespace ImageMarkingContract.DTO
{
   public class CreateShareDocumentResponseOK:CreateShareDocumentResponse
    {
        public string DocID { get; set; }
        public string UserID { get; set; }
        public CreateShareDocumentResponseOK(string docID,string userID)
        {
            DocID = docID;
            UserID = userID;
        }
     
    }
}
