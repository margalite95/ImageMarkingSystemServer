using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.Interface;
using System;

namespace CreateDocumentsService
{
    [Register(Policy.Transient, typeof(ICreateDocumentsService))]

    public class CreateDocumentsServiceImpl : ICreateDocumentsService
    {
        IImageMarkingDocumentsDAL _dal;
        public CreateDocumentsServiceImpl(IImageMarkingDocumentsDAL dal)
        {
            _dal = dal;

        }
        public Response CreateDocument(CreateDocumentsRequest request)
        {
            try
            {
                var guid = Guid.NewGuid();
                var ds = _dal.CreateDocuments(request.Owner,request.ImageUrl,request.DocumentName,guid.ToString());

                var tbl = ds.Tables[0];
                CreateDocumentsResponse retval = new CreateDocumentsResponse();
                if (tbl.Rows.Count == 1)
                {
                    if (request.Owner == (string)tbl.Rows[0][0]
                        && request.ImageUrl == (string)tbl.Rows[0][1]
                         && request.DocumentName == (string)tbl.Rows[0][2])
                    {
                        retval = new CreateDocumentsResponseOK((string)tbl.Rows[0][0], (string)tbl.Rows[0][1]
                            , (string)tbl.Rows[0][2], (string)tbl.Rows[0][3]);
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

