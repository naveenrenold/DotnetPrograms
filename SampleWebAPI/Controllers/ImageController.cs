namespace Sample.Controllers.Image
{
    using Microsoft.AspNetCore.Mvc;
    using Sample.Model;
    using Sample.Business.Interface;
    
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        public readonly IImageBusiness iImageBusiness;
        public ImageController(IImageBusiness iImageBusiness)
        {
            this.iImageBusiness=iImageBusiness;
        }    
    [HttpPost]
    public IActionResult Post([FromForm] Image value)
    {
        return Ok(iImageBusiness.SaveImage(value));
    }
    }
}