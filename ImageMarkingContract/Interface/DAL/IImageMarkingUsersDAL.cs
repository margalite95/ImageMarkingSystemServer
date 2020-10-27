using ImageMarkingContract.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ImageMarkingContract.Interface
{
    public interface IImageMarkingUsersDAL
    {
        public DataSet CreateUser(string email, string userName);
        public DataSet GetUser(string userName);

        public DataSet UnSubscribeUser(string email);
    }
}
