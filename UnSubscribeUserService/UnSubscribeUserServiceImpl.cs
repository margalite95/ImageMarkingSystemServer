using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.Interface;
using System;

namespace UnSubscribeUserService
{
    [Register(Policy.Transient, typeof(IUnSubscribeUserService))]
    public class UnSubscribeUserServicImpl:IUnSubscribeUserService
    {
        IImageMarkingUsersDAL _dal;
        public UnSubscribeUserServicImpl(IImageMarkingUsersDAL dal)
        {
            _dal = dal;
        }

        public Response UnSubscribeUser(UnSubscribeUserRequest request)
        {
            try
            {
                var ds = _dal.UnSubscribeUser(request.Email);
                var tbl = ds.Tables[0];
                UnSubscribeUserResponse retval = new UnSubscribeUserInvalidEmailResponse(request.Email);
                if (tbl.Rows.Count == 1)
                {
                    if (request.Email == (string)tbl.Rows[0][0]
                        && (Int16)tbl.Rows[0][2]==0)
                    {
                        retval = new UnSubscribeUserResponseOK((string)tbl.Rows[0][0], (string)tbl.Rows[0][1],
                        true);
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
