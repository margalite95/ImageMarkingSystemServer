using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.Interface;
using System.IO;

namespace UploadImageService
{
    [Register(Policy.Transient, typeof(IUploadImageService))]

    public class UploadImageServiceImpl : IUploadImageService
    {
        public Response UploadImage(UploadImageRequest request)
        {
            var filePath = Path.Combine("images", request.ImageUrl.FileName);
            if (request.ImageUrl.Length > 0)
            {
                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    request.ImageUrl.CopyTo(fileStream);
                }
               
            }
            return new UploadImageResponseOK(filePath, request.ImageUrl.FileName);

        }
    }
}
