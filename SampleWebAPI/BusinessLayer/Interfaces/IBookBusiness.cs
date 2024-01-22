namespace Sample.Business.Interface
{
    using Sample.Model;
    public interface IBookBusiness
    {
        public IEnumerable<Book> GetBook();
        public bool AddBook(List<Book> book);
    }    
}