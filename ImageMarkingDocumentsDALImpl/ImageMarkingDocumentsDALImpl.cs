using DALContracts;
using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.Interface;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using OracleDAL;
using System;
using System.Data;

namespace ImageMarkingDocumentsDAL
{
    [Register(Policy.Transient, typeof(IImageMarkingDocumentsDAL))]

    public class ImageMarkingDocumentsDALImpl : IImageMarkingDocumentsDAL
    {
        IDBConnection _conn;

        IInfraDAL _infraDAL;
        IConfiguration _configuration;
        public ImageMarkingDocumentsDALImpl(IInfraDAL infraDAL, IConfiguration configuration)
        {
            _infraDAL = infraDAL;
            _configuration = configuration;
            _conn = _infraDAL.Connect(_configuration.GetConnectionString("ImageMarkingDB"));
        }
        public DataSet CreateDocuments(string owner,string imageUrl,string documentName,string guid)
        {
            
            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_OWNER", "Varchar2", owner);
            IDBParameter param1 = _infraDAL.getParameter("P_IMAGEURL", "Varchar2", imageUrl);
            IDBParameter param2 = _infraDAL.getParameter("P_DOCUMENTNAME", "Varchar2", documentName);
            IDBParameter param3 = _infraDAL.getParameter("P_DOCID", "Varchar2", guid);
            var retval= _infraDAL.ExecuteSPQuery(_conn, "CREATEDOCUMENT", param, param1,param2,param3, output);
            return retval;
        }

        public DataSet RemoveDocument(string docID)
        {
            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_DOCID", "Varchar2", docID);
            return _infraDAL.ExecuteSPQuery(_conn, "REMOVEDOCUMENT", param,output);
        }
        public DataSet GetDocuments(string docID)
        {
            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_OWNER", "Varchar2", docID);
            return _infraDAL.ExecuteSPQuery(_conn, "GETDOCUMENTS", param, output);
        }
    }



}
