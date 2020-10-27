using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO
{
    public class SignInResponseOK:SignInResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public SignInResponseOK(string email,string userName)
        {
            Email=email;
            UserName = userName;
        }
      
      
    }
}
