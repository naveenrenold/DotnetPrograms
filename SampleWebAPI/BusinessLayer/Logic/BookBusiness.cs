namespace Book.Business.Logic{
    using System.Collections;
    using Book.Model;
    using Book.Business.Interface;
    using Book.Data.Interface;
    public class BookBusiness:IBookBusiness{
        public readonly IBookData iBookData;
        public BookBusiness(IBookData iBookData)
        {
            this.iBookData=iBookData;
        }
        public  IEnumerable<Book>GetBook()
        {
            return iBookData.GetBook();                        
        }
        public  bool AddBook(List<Book> book)
        {
            return iBookData.AddBook(book);                        
        }
    }
}