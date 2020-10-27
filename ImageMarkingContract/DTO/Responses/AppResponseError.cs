using DIContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO
{
    public class AppResponseError:Response
    {
        public AppResponseError(string msg)
        {
            Message = msg;
        }
        public string Message { get; }
    }
}
