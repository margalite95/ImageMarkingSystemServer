using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO
{
    public class RemoveDocumentsResponseOK:RemoveDocumentsResponse
    {
        public RemoveDocumentsResponseOK(RemoveDocumentsRequest request)
        {
            Request = request;
        }
        public RemoveDocumentsRequest Request { get; }
    }
}
