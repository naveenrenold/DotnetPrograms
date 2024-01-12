namespace Book.Business.Interface
{
    using Book.Model;
    public interface IBookBusiness
    {
        public IEnumerable<Book> GetBook();
        public bool AddBook(List<Book> book);
    }    
}