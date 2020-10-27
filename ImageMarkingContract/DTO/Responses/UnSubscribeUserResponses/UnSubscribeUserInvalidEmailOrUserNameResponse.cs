using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO
{
   public class UnSubscribeUserInvalidEmailResponse:UnSubscribeUserResponse
    {
        public UnSubscribeUserInvalidEmailResponse(string email)
        {
            Email = email;
        }
        public string Email { get; }
    }
}
