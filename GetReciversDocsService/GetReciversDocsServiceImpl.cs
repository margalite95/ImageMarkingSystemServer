using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.DTO.Requests;
using ImageMarkingContract.DTO.Responses.GetReciversDocsResponses;
using ImageMarkingContract.Interface;
using ImageMarkingContract.Interface.BLL;
using System;
using System.Collections.Generic;

namespace GetReciversDocsService
{
    [Register(Policy.Transient, typeof(IGetReciversDocsService))]
    public class GetReciversDocsServiceImpl: IGetReciversDocsService
    {
        IMessanger _messanger;
       
        public GetReciversDocsServiceImpl(IMessanger messanger)
        {
            _messanger = messanger;

        }

        public Response GetReciversDocs(GetReciversDocsRequest request)
        {
            IEnumerable<string> rd;
            GetReciversDocsResponse retval;
            try
            {
                rd=_messanger.GetReciversDocs(request.DocID);

                retval = new GetReciversDocsResponseOK(rd);
                return retval;

            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }


        }
    }
}
