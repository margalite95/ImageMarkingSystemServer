using ImageMarkingContract.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ImageMarkingContract.Interface
{
    public interface IImageMarkingShareDocumentsDAL
    {
        public DataSet CreateShareDocument(string docID, string userID);
        public DataSet GetSharedDocuments(string docID);
        public DataSet RemoveSharedDocument(string docID,string userID);
        public DataSet GetSharedUsers(string docID);

    }
}
