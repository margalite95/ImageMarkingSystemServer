using DALContracts;
using DIContract;
using ImageMarkingContract.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ImageMarkingUsersDAL
{
    [Register(Policy.Transient, typeof(IImageMarkingUsersDAL))]
    public class ImageMarkingUsersDALImpl:IImageMarkingUsersDAL
    {

        IDBConnection _conn;
        IInfraDAL _infraDAL;
        IConfiguration _configuration;
        public ImageMarkingUsersDALImpl(IInfraDAL infraDAL, IConfiguration configuration)
        {
            _infraDAL = infraDAL;
            _configuration = configuration;
            _conn = _infraDAL.Connect(_configuration.GetConnectionString("ImageMarkingDB"));
        }

        public DataSet CreateUser(string email, string userName)
        {
            IDBParameter output =_infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_USERID", "Varchar2", email);
            IDBParameter param1 = _infraDAL.getParameter("P_USERNAME", "Varchar2", userName);
            return _infraDAL.ExecuteSPQuery(_conn, "CREATEUSER", param, param1, output);
        }

        public DataSet GetUser(string email)
        {
            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_USERID", "Varchar2", email);
            return _infraDAL.ExecuteSPQuery(_conn, "LOGIN", param, output);
        }

        public DataSet UnSubscribeUser(string email)
        {
            IDBParameter output = _infraDAL.getParameter("RETVAL", "RefCursor", ParameterDirection.Output);
            IDBParameter param = _infraDAL.getParameter("P_USERID", "Varchar2", email);
            return _infraDAL.ExecuteSPQuery(_conn, "REMOVEUSER", param,output);
        }



    }
}
