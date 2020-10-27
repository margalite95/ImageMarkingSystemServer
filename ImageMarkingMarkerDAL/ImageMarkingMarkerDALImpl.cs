using DALContracts;
using DIContract;
using ImageMarkingContract.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace ImageMarkingMarkerDAL
{
    [Register(Policy.Transient, typeof(IImageMarkingMarkerDAL))]

    public class ImageMarkingMarkerDALImpl: IImageMarkingMarkerDAL
    {
        IDBConnection _conn;

        IInfraDAL _infraDAL;

        IConfiguration _configuration;

        public ImageMarkingMarkerDALImpl(IInfraDAL infraDAL, IConfiguration configuration)

        {
            _infraDAL = infraDAL;
            _configuration = configuration;
            _conn = _infraDAL.Connect(_configuration.GetConnectionString("ImageMarkingDB"));
        }

        public DataSet CreateMarker(string docID, string markerID, string markerType, Decimal centerX,
            Decimal centerY, Decimal rediusX, Decimal rediusY,string foreColor,string backColor,string userID)
        {
            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_DocID", "Varchar2", docID);
            IDBParameter param1 = _infraDAL.getParameter("P_MarkerID", "Varchar2", markerID);
            IDBParameter param2 = _infraDAL.getParameter("P_MarkerType", "Varchar2", markerType);
            IDBParameter param3 = _infraDAL.getParameter("P_CenterX", "Number", centerX);
            IDBParameter param4 = _infraDAL.getParameter("P_CenterY", "Number", centerY);
            IDBParameter param5 = _infraDAL.getParameter("P_RadiusX", "Number", rediusX);
            IDBParameter param6 = _infraDAL.getParameter("P_RadiusY", "Number", rediusY);
            IDBParameter param7 = _infraDAL.getParameter("P_ForeColor", "Varchar2", foreColor);
            IDBParameter param8 = _infraDAL.getParameter("P_BackColor", "Varchar2", backColor);
            IDBParameter param9 = _infraDAL.getParameter("P_UserID", "Varchar2", userID);

            var retval = _infraDAL.ExecuteSPQuery(_conn, "CREATEMARKER", param, param1, param2, param3, param4, param5, param6, param7, param8, param9, output);
            return retval;
        }

        public DataSet RemoveMarker(string docID,string markerID)
        {
            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_DocID", "Varchar2", docID);
            IDBParameter param1 = _infraDAL.getParameter("P_MarkerID", "Varchar2", markerID);
            return _infraDAL.ExecuteSPQuery(_conn, "REMOVEMARKER", param, param1,output);
        }
        public DataSet GetMarker(string docID)
        {
            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_DocID", "Varchar2", docID);
            return _infraDAL.ExecuteSPQuery(_conn, "GETMARKERS", param,output);
        }
        public DataSet Editcolor(string docID, string markerID,string foreColor, string backColor, string userID)
        {
            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_DocID", "Varchar2", docID);
            IDBParameter param1 = _infraDAL.getParameter("P_MarkerID", "Varchar2", markerID);
            IDBParameter param2 = _infraDAL.getParameter("P_ForeColor", "Varchar2", foreColor);
            IDBParameter param3 = _infraDAL.getParameter("P_BackColor", "Varchar2", backColor);
            IDBParameter param4 = _infraDAL.getParameter("P_UserID", "Varchar2", userID);

            var retval = _infraDAL.ExecuteSPQuery(_conn, "EDITCOLORS", param, param1, param2, param3, param4, output);
            return retval;
        }
    }
}
