using ImageMarkingContract.DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ImageMarkingContract.DTO
{
   public class GetDocumentsResponseOK: GetDocumentsResponse
    {      
        public List<Documents> documents { get; set; }

        public List<Documents> shareDocuments { get; set; }
        public GetDocumentsResponseOK(List<Documents> documentsList, List<Documents> shareDocumentsList)
            {
            documents = new List<Documents>();
            shareDocuments = new List<Documents>();

            documents = documentsList;
            shareDocuments = shareDocumentsList;
            }        
    }
}

