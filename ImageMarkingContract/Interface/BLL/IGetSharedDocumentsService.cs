using DIContract;
using ImageMarkingContract.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.Interface
{
    public interface IGetSharedDocumentsService
    {
        Response GetSharedDocuments(GetSharedDocumentsRequest request);

    }
}
