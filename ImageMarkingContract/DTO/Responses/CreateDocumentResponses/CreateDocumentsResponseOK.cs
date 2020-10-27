using System;


namespace ImageMarkingContract.DTO
{
    public class CreateDocumentsResponseOK : CreateDocumentsResponse
    {
        public string Owner { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentName { get; set; }
        public string DocID { get; set; }
        public CreateDocumentsResponseOK(string owner, string imageUrl,string documentName,string docID)
        {
            Owner = owner;
            ImageUrl = imageUrl;
            DocumentName = documentName;
            DocID = docID;
        }
    }
}