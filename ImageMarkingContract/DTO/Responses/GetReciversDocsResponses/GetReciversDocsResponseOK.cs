using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO.Responses.GetReciversDocsResponses
{
   public class GetReciversDocsResponseOK: GetReciversDocsResponse
    {
        public IEnumerable<string> Request { get; set; }
        public GetReciversDocsResponseOK(IEnumerable<string> request)
        {
            Request = request;
        }
    }
}
