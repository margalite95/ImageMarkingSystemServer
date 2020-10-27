
using Microsoft.AspNetCore.Http;


namespace ImageMarkingContract.DTO
{
   public class UploadImageRequest
    {
        public IFormFile ImageUrl { get; set; }
    }
}
