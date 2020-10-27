using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.Interface;
using System;

namespace RemoveShareDocumentService
{
    [Register(Policy.Transient, typeof(IRemoveShareDocumentService))]
    public class RemoveShareDocumentServiceImpl:IRemoveShareDocumentService
    {
        IImageMarkingShareDocumentsDAL _dal;
        public RemoveShareDocumentServiceImpl(IImageMarkingShareDocumentsDAL dal)
        {
            _dal = dal;

        }
        public Response RemoveSharedDocuments(RemoveSharedDocumentsRequest request)
        {
            try
            {
                var ds = _dal.RemoveSharedDocument(request.DocID,request.UserID);
                var tbl = ds.Tables[0];
                RemoveShareDocumentResponse retval = new RemoveShareDocumentResponse();
                if (tbl.Rows.Count == 0)
                {
                    retval = new RemoveShareDocumentResponseOK(request);

                }
                return retval;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }


        }
    }
}
