namespace Sample.Data.Interface
{
    using Sample.Model;
    public interface IBookData
    {
        public  IEnumerable<Book> GetBook();
        public  bool AddBook(List<Book>book);
    }    
}