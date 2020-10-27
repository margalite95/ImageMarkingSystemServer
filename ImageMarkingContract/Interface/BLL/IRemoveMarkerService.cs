using DIContract;
using ImageMarkingContract.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.Interface
{
   public interface IRemoveMarkerService
    {
        Response RemoveMarker(RemoveMarkerRequest request);

    }
}
