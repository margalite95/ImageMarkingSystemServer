
namespace ImageMarkingContract.DTO
{
   public class Documents
    {
        public string Owner { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentName { get; set; }
        public string DocID { get; set; }

        public Documents(string owner, string imageUrl, string documentName, string docID)
        {
            Owner = owner;
            ImageUrl = imageUrl;
            DocumentName = documentName;
            DocID = docID;
        }
    }
}
