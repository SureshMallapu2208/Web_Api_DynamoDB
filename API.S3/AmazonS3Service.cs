using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.Util.Internal;
using Microsoft.AspNetCore.Http;

namespace API.S3
{
    public class AmazonS3Service : IAmazonS3Service
    {
        private const string _bucketName = "";


        private readonly IAmazonS3 _client;
        public AmazonS3Service(IAmazonS3 client)
        {
            _client = client;
        }
        public async Task<bool> UploadFileAsync(IFormFile file)
        {
            try
            {
                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);

                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = newMemoryStream,
                        Key = file.FileName,
                        BucketName = _bucketName,
                        ContentType = file.ContentType
                    };

                    var fileTransferUtility = new TransferUtility(_client);

                    await fileTransferUtility.UploadAsync(uploadRequest);

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}