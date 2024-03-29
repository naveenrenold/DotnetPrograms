namespace Sample.Data.Logic{
    using System.Collections;
    using Sample.Model;
    using Sample.Data.Interface;
    using System.Data.SqlClient;    
    using Azure.Storage.Blobs;    

    public class ImageData:IImageData{
        public readonly SqlConnection sqlConnection;
        public readonly BlobServiceClient blobServiceClient;
        public ImageData(IDALBase iDalBase,BlobServiceClient blobServiceClient)
        {
            this.sqlConnection=iDalBase.Connect();
            this.blobServiceClient=blobServiceClient;
        }
        public bool SaveImage(Image image)
        {            
            var blobClient=blobServiceClient.GetBlobContainerClient("testblob");            
            try{
            var success=blobClient.UploadBlob(image.ImageName,image.ImageBytes.OpenReadStream());
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{image.ImageName} upload failed. Error at {ex.StackTrace} with exception {ex.Message}");
                return false;
            }
            return true;
        }
    }
}