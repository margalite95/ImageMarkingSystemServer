using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.Interface;
using System;

namespace SignInService
{
    [Register(Policy.Transient, typeof(ISignInService))]
    public class SignInServiceImpl : ISignInService
    {
        IImageMarkingUsersDAL _dal;
        public SignInServiceImpl(IImageMarkingUsersDAL dal)
        {
            _dal = dal;
        }
        public Response SignIn(SignInRequest request)
        {
            try
            {
                var ds = _dal.GetUser(request.Email);
          
                SignInResponse retval = new SignInInvalidEmailResponse(request.Email);
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        if (request.Email == (string)tbl.Rows[0][0])
                        {
                            retval = new SignInResponseOK((string)tbl.Rows[0][0], (string)tbl.Rows[0][1]);
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
