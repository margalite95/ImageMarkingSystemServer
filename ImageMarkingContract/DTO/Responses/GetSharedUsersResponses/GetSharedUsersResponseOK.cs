using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO.Responses.GetSharedUsersResponses
{
  public  class GetSharedUsersResponseOK: GetSharedUsersResponse
    {

        public List<string> Request { get; set; }
        public GetSharedUsersResponseOK(List<string> request)
        {
            Request = request;
        }
    }
}
