using DIContract;
using ImageMarkingContract.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.Interface
{
    public interface IUnSubscribeUserService
    {
        Response UnSubscribeUser(UnSubscribeUserRequest request);
    }
}
