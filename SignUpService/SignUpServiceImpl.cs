using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.Interface;
using System;

namespace SignUpService
{
    [Register(Policy.Transient, typeof(ISignUpService))]
    public class SignUpServiceImpl:ISignUpService
    {
        IImageMarkingUsersDAL _dal;
        public SignUpServiceImpl(IImageMarkingUsersDAL dal)
        {
            _dal = dal;
        }

         public Response SignUp(SignUpRequest request)
             {
                 try
                 {
                    SignUpResponse retval = new SignUpResponse();
                    var gu = _dal.GetUser(request.Email);
                    var tblga= gu.Tables[0];
                if (tblga.Rows.Count == 1)
                {
                    retval = new SignUpUserNameAlreadyExists();
                }
                else
                {
                    var ds = _dal.CreateUser(request.Email, request.UserName);
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        if (request.Email == (string)tbl.Rows[0][0]
                            && request.UserName == (string)tbl.Rows[0][1])
                        {
                            retval = new SignUpResponseOK((string)tbl.Rows[0][0], (string)tbl.Rows[0][1]);
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

