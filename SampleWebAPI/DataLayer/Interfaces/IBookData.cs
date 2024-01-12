namespace Book.Data.Interface
{
    using Book.Model;
    public interface IBookData
    {
        public  IEnumerable<Book> GetBook();
        public  bool AddBook(List<Book>book);
    }    
}