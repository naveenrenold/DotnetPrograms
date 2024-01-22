namespace Sample.Controllers.Book
{
    using Microsoft.AspNetCore.Mvc;
    using Sample.Model;
    using Sample.Business.Interface;
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IBookBusiness iBookBusiness;
        public BookController(IBookBusiness iBookBusiness)
        {
            this.iBookBusiness=iBookBusiness;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(iBookBusiness.GetBook());            
        }    
    [HttpPost]
    public IActionResult Post([FromBody] List<Book> value)
    {
        return Ok(iBookBusiness.AddBook(value));
    }
    }
}
