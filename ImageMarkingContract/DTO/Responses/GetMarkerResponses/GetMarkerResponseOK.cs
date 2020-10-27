using ImageMarkingContract.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO.Responses.GetMarkerResponses
{
   public class GetMarkerResponseOK: GetMarkerResponse
    {
        public List<Marker> Markers { get; set; }
        public GetMarkerResponseOK(List<Marker> markers)
        {
            Markers = markers;
        }
    }
}
