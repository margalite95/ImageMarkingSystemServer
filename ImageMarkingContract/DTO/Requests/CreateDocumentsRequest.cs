using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO
{
    public class CreateDocumentsRequest
    {
        public string Owner { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentName { get; set; }



    }
}
