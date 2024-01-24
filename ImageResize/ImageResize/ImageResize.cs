using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ImageMagick;
using Azure.Storage.Blobs;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace ImageResize
{
    public class ImageResize
    {
        [FunctionName("ImageResize")]
        public void Run([BlobTrigger("testblob/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processing started\n Name:{name} \n Size: {myBlob.Length} Bytes");
            MagickNET.Initialize();
            var image = new MagickImage(myBlob);
            var size = new MagickGeometry(100,100);
            size.IgnoreAspectRatio=true;
            image.Resize(size);
            var imageBytes=image.ToByteArray();           
            var memStream = new MemoryStream(imageBytes);            
            var blobClient = new BlobServiceClient(System.Environment.GetEnvironmentVariable("BLOB_STORAGE_CONNECTIONSTRING"));
            var blobContainerClient = blobClient.GetBlobContainerClient("testblob");
            try
            {
                blobContainerClient.UploadBlob("resized"+name,memStream);
            }
            catch(Exception ex)
            {
                log.LogInformation($"{name} upload failed. Error at {ex.StackTrace} with exception {ex.Message}");
                
            }
            log.LogInformation($"C# Blob trigger function Processing ended\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
