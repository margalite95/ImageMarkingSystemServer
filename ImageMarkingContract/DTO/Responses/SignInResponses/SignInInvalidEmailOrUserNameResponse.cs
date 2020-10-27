using DIContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO
{
    public class SignInInvalidEmailResponse: SignInResponse
    {
        public SignInInvalidEmailResponse(string email)
        {
            Email = email;
        }
        public string Email { get; }
    }
}
