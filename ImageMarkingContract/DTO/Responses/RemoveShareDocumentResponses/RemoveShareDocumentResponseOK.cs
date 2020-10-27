using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO
{
   public class RemoveShareDocumentResponseOK:RemoveShareDocumentResponse
    {
        public RemoveShareDocumentResponseOK(RemoveSharedDocumentsRequest request)
        {
            Request = request;
        }
        public RemoveSharedDocumentsRequest Request { get; }

    }
}
