using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.Interface;
using System;


namespace RemoveDocumentService
{
    [Register(Policy.Transient, typeof(IRemoveDocumentService))]
    public class RemoveDocumentServiceImpl: IRemoveDocumentService
    {

        IImageMarkingDocumentsDAL _dal;
        public RemoveDocumentServiceImpl(IImageMarkingDocumentsDAL dal)
        {
            _dal = dal;

        }
        public Response RemoveDocument(RemoveDocumentsRequest request)
        {
            try
            {
                var ds = _dal.RemoveDocument(request.DocID);
                var tbl = ds.Tables[0];
                RemoveDocumentsResponse retval = new RemoveDocumentsResponse();
                if (tbl.Rows.Count == 0)
                    {
                        retval = new RemoveDocumentsResponseOK(request);
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
