
using System.Data;


namespace ImageMarkingContract.Interface
{
    public interface IImageMarkingDocumentsDAL
    {
        public DataSet CreateDocuments(string owner, string imageUrl, string documentName, string guid);
        public DataSet RemoveDocument(string docID);
        public DataSet GetDocuments(string docID);
    }
}
