using Microsoft.AspNetCore.Http;

namespace API.S3
{
    public interface IAmazonS3Service
    {
        Task<bool> UploadFileAsync(IFormFile file);
    }
}
