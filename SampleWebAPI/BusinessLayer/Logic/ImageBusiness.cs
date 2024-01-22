namespace Sample.Business.Logic{
    using System.Collections;
    using Sample.Model;
    using Sample.Business.Interface;
    using Sample.Data.Interface;
    public class ImageBusiness:IImageBusiness{
        public readonly IImageData iImageData;
        public ImageBusiness(IImageData iImageData)
        {
            this.iImageData=iImageData;
        }
        public  bool SaveImage(Image Image)
        {
            return iImageData.SaveImage(Image);                        
        }
    }
}