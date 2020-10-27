using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.DTO.Requests;
using ImageMarkingContract.DTO.Responses;
using ImageMarkingContract.Interface;
using System;

namespace CreateMarkerService
{
    [Register(Policy.Transient, typeof(ICreateMarkerService))]

    public class CreateMarkerServiceImpl: ICreateMarkerService
    {
        IMessanger _messanger;
        IImageMarkingMarkerDAL _dal;
        public CreateMarkerServiceImpl(IImageMarkingMarkerDAL dal,IMessanger messanger)
        {
            _messanger = messanger;
            _dal = dal;
        }
        public Response CreateMarker(CreateMarkerRequest request)
        {
            try
            {
                var guid = Guid.NewGuid();
                var ds = _dal.CreateMarker(request.DocID, guid.ToString(), request.MarkerType,
                    request.CenterX, request.CenterY, request.RadiusX, request.RadiusY,
                    request.ForeColor, request.BackColor, request.UserID);

                var tbl = ds.Tables[0];
                CreateMarkerResponse retval = new CreateMarkerResponse();
                if (tbl.Rows.Count >= 1)
                {
                    if (request.DocID == (string)tbl.Rows[0][0] && request.MarkerType == (string)tbl.Rows[0][2] &&
                    request.CenterX == (Decimal)tbl.Rows[0][3] && request.CenterY == (Decimal)tbl.Rows[0][4] &&
                    request.RadiusX == (Decimal)tbl.Rows[0][5] && request.RadiusY == (Decimal)tbl.Rows[0][6] &&
                    request.ForeColor == (string)tbl.Rows[0][7] && request.BackColor == (string)tbl.Rows[0][8] &&
                    request.UserID == (string)tbl.Rows[0][9])
                    {
                        _messanger.Send(request.UserID, request.DocID, "newMarker");
                        retval = new CreateMarkerResponseOK((string)tbl.Rows[0][0], (string)tbl.Rows[0][1],
                            (string)tbl.Rows[0][2], (Decimal)tbl.Rows[0][3], (Decimal)tbl.Rows[0][4], (Decimal)tbl.Rows[0][5],
                            (Decimal)tbl.Rows[0][6], (string)tbl.Rows[0][7], (string)tbl.Rows[0][8], (string)tbl.Rows[0][9]);
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
