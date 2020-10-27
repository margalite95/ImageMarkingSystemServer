using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.Interface;
using System;

namespace GetSharedDocumentsService
{
    [Register(Policy.Transient, typeof(IGetSharedDocumentsService))]
    public class GetSharedDocumentsServiceImpl : IGetSharedDocumentsService
    {
        IImageMarkingShareDocumentsDAL _dal;
        public GetSharedDocumentsServiceImpl(IImageMarkingShareDocumentsDAL dal)
        {
            _dal = dal;
        }
        public Response GetSharedDocuments(GetSharedDocumentsRequest request)
        {
            try
            {
                var ds = _dal.GetSharedDocuments(request.DocID);

                GetSharedDocumentsResponse retval = new GetSharedDocumentsResponse();
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count > 0)
                    {
                        if (request.DocID == (string)tbl.Rows[0][0])
                        {
                            retval = new GetSharedDocumentsResponseOK((string)tbl.Rows[0][0], (string)tbl.Rows[0][1]);
                        }
                    }
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
