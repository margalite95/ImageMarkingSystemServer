using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.DTO.Models;
using ImageMarkingContract.DTO.Requests;
using ImageMarkingContract.DTO.Responses.GetMarkerResponses;
using ImageMarkingContract.Interface;
using System;
using System.Collections.Generic;

namespace GetMarkerService
{
    [Register(Policy.Transient, typeof(IGetMarkerService))]
    public class GetMarkerServiceImpl : IGetMarkerService
    {
        IImageMarkingMarkerDAL _dal;
        public GetMarkerServiceImpl(IImageMarkingMarkerDAL dal)
        {
            _dal = dal;
        }
        public Response GetMarker(GetMarkerRequest request)
        {
            try
            {
                var ds = _dal.GetMarker(request.DocID);
                List<Marker> dl = new List<Marker>();
                GetMarkerResponse retval = new GetMarkerResponse();
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count > 0)
                    {
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            if (request.DocID == (string)tbl.Rows[0][0])
                            {
                                Marker dc = new Marker((string)tbl.Rows[i][0], (string)tbl.Rows[i][1], (string)tbl.Rows[i][2],
                                (Decimal)tbl.Rows[i][3], (Decimal)tbl.Rows[i][4], (Decimal)tbl.Rows[i][5],
                                (Decimal)tbl.Rows[i][6], (string)tbl.Rows[i][7], (string)tbl.Rows[i][8], (string)tbl.Rows[i][9]);
                                dl.Add(dc);
                            }
                        }
                     
                        retval = new GetMarkerResponseOK(dl);


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
