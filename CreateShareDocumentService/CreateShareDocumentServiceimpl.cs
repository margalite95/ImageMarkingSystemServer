using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.DTO.Responses.CreateShareDocumentResponses;
using ImageMarkingContract.Interface;
using System;

namespace CreateShareDocumentService
{
    [Register(Policy.Transient, typeof(ICreateShareDocumentService))]

    public class CreateShareDocumentServiceimpl : ICreateShareDocumentService
    {
        IImageMarkingShareDocumentsDAL _dal;
        IImageMarkingUsersDAL _userDAL;
        public CreateShareDocumentServiceimpl(IImageMarkingShareDocumentsDAL dal, IImageMarkingUsersDAL userDAL)
        {
            _dal = dal;
            _userDAL = userDAL;
        }
        public Response CreateShareDocument(CreateShareDocumentRequest request)
        {
            try
            {
                
                
                CreateShareDocumentResponse retval = new CreateShareDocumentUserNotExistsResponse();
                var userAlreadyExists = _userDAL.GetUser(request.UserID);
                if (userAlreadyExists.Tables.Count > 0)
                {
                    var tbl = userAlreadyExists.Tables[0];
                    if (tbl.Rows.Count > 0)
                    {
                        var ds = _dal.CreateShareDocument(request.DocID, request.UserID);
                        var tbl1 = ds.Tables[0];
                     
                        retval = new CreateShareDocumentResponseOK((string)tbl.Rows[0][0], (string)tbl.Rows[0][1]);
                        
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

