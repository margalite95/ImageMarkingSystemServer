using DALContracts;
using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.Interface;
using Oracle.ManagedDataAccess.Client;
using OracleDAL;
using System;
using System.Collections.Specialized;
using System.Data;

namespace ImageMarkingShareDocumentsDAL
{
    [Register(Policy.Transient, typeof(IImageMarkingShareDocumentsDAL))]
    public class ImageMarkingShareDocumentsDALImpl: IImageMarkingShareDocumentsDAL
    {

        IDBConnection _conn;

        IInfraDAL _infraDAL;
        public ImageMarkingShareDocumentsDALImpl(IInfraDAL infraDAL)
        {
            _infraDAL = infraDAL;
            var strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=ms;Password=1234;";
            _conn = _infraDAL.Connect(strConn);
        }

        public DataSet CreateShareDocument(string docID,string userID)
        {
            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_DOCID", "Varchar2", docID);
            IDBParameter param1 = _infraDAL.getParameter("P_USERID", "Varchar2", userID);
            return _infraDAL.ExecuteSPQuery(_conn, "CREATESHARE", param,param1, output);
        }

        public DataSet GetSharedDocuments(string userID)
        {
            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_USERID", "Varchar2", userID);
            return _infraDAL.ExecuteSPQuery(_conn, "GETSHAREDDOCUMENTS", param, output);
        }

        public DataSet GetSharedUsers(string docID)
        {

            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_DOCID", "Varchar2", docID);
            return _infraDAL.ExecuteSPQuery(_conn, "GETSHAREDUSERES", param, output);
        }

        public DataSet RemoveSharedDocument(string docID,string userID)
        {
            
               IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_DOCID", "Varchar2", docID);
            IDBParameter param1 = _infraDAL.getParameter("P_USERID", "Varchar2", userID);
            return _infraDAL.ExecuteSPQuery(_conn, "REMOVESHARE", param, param1,output);
        }
    }
}
