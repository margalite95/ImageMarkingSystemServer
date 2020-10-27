using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO
{
    public class UploadImageResponseOK : UploadImageResponse
    {
        public string ImageUrl { get; set; }
        public string DocumentName { get; set; }
        public UploadImageResponseOK(string imageUrl, string docName)
        {
            ImageUrl = imageUrl;
            DocumentName = docName;
        }
    }
}

