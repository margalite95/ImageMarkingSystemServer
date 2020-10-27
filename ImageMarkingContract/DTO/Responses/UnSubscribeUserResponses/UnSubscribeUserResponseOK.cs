using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO
{
    public class UnSubscribeUserResponseOK:UnSubscribeUserResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsRemoved { get; set; }
        public UnSubscribeUserResponseOK(string email, string userName,bool isRemoved)
        {
            Email = email;
            UserName = userName;
            IsRemoved = isRemoved;
        }
    }
}
