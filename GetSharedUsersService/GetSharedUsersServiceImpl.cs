using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.DTO.Requests;
using ImageMarkingContract.DTO.Responses.GetSharedUsersResponses;
using ImageMarkingContract.Interface;
using ImageMarkingContract.Interface.BLL;
using System;
using System.Collections.Generic;

namespace GetSharedUsersService
{

    [Register(Policy.Transient, typeof(IGetSharedUsersService))]
    public class GetSharedUsersServiceImpl : IGetSharedUsersService
    {
        IImageMarkingShareDocumentsDAL _dal;
        public GetSharedUsersServiceImpl(IImageMarkingShareDocumentsDAL dal)
        {
            _dal = dal;
        }
        public Response GetSharedUsers(GetSharedUsersRequest request)
        {
            try
            {
                var ds = _dal.GetSharedUsers(request.DocID);
                List<string> sharesUsers=new List<string>();
                GetSharedUsersResponse retval = new GetSharedUsersNotExistResponse();
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                            var su = (string)tbl.Rows[i][0];
                            sharesUsers.Add(su);
                        
                    }
                    if (sharesUsers.Count > 0)
                    {
                        retval = new GetSharedUsersResponseOK(sharesUsers);
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