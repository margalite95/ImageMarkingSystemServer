using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO
{
    public class SignUpResponseOK:SignUpResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public SignUpResponseOK(string email, string userName)
        {
            Email = email;
            UserName = userName;
        }
    }
}
