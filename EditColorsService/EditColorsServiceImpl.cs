using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.DTO.Requests;
using ImageMarkingContract.DTO.Responses.EditColorsResponses;
using ImageMarkingContract.Interface;
using ImageMarkingContract.Interface.BLL;
using System;

namespace EditColorsService
{
    [Register(Policy.Transient, typeof(IEditColorsService))]
    public class EditColorsServiceImpl:IEditColorsService
    {
        IMessanger _messanger;
        IImageMarkingMarkerDAL _dal;
        public EditColorsServiceImpl(IImageMarkingMarkerDAL dal, IMessanger messanger)
        {
            _messanger = messanger;
            _dal = dal;
        }
        public Response EditColors(EditColorRequest request)
        {
            try
            {
                var ds = _dal.Editcolor(request.DocID,request.MarkerID,request.ForeColor,
                    request.BackColor,request.UserID);

                EditColorsResponse retval = new EditColorsResponse();
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        if (request.DocID == (string)tbl.Rows[0][0] && request.MarkerID == (string)tbl.Rows[0][1] &&
                            request.ForeColor == (string)tbl.Rows[0][7] && request.BackColor == (string)tbl.Rows[0][8] &&
                            request.UserID == (string)tbl.Rows[0][9])
                        {
                            _messanger.Send(request.UserID, request.DocID, "editMarkerColor");
                            retval = new EditColorsResponseOK((string)tbl.Rows[0][0], (string)tbl.Rows[0][1],
                                  (string)tbl.Rows[0][2], (Decimal)tbl.Rows[0][3], (Decimal)tbl.Rows[0][4], (Decimal)tbl.Rows[0][5],
                                  (Decimal)tbl.Rows[0][6], (string)tbl.Rows[0][7], (string)tbl.Rows[0][8], (string)tbl.Rows[0][9]);
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
