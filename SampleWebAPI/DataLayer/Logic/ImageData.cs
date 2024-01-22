namespace Sample.Data.Logic{
    using System.Collections;
    using Sample.Model;
    using Sample.Data.Interface;
    using System.Data.SqlClient;
    using Dapper;
    using Sample.Data;
    using Azure.Storage.Blobs;

    public class ImageData:IImageData{
        public readonly SqlConnection sqlConnection;
        public readonly BlobServiceClient blobServiceClient;
        public ImageData(IDALBase iDalBase,BlobServiceClient blobServiceClient)
        {
            this.sqlConnection=iDalBase.Connect();
            this.blobServiceClient=blobServiceClient;
        }
        public bool SaveImage(Image Image)
        {            
            blobServiceClient.
        }
    }
}