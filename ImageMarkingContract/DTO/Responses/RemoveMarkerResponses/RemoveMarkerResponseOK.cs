using ImageMarkingContract.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO.Responses
{
  public class RemoveMarkerResponseOK: RemoveMarkerResponse
    {
        public RemoveMarkerResponseOK(RemoveMarkerRequest request)
        {
            Request = request;
        }
        public RemoveMarkerRequest Request { get; }
    }
}
