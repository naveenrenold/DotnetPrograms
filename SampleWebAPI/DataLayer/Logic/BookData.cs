namespace Sample.Data.Logic{
    using System.Collections;
    using Sample.Model;
    using Sample.Data.Interface;
    using System.Data.SqlClient;
    using Dapper;

    public class BookData:IBookData{
        public readonly SqlConnection sqlConnection;
        public BookData(IDALBase iDalBase)
        {
            this.sqlConnection=iDalBase.Connect();
        }
        public IEnumerable<Book>GetBook()
        
        {
            var book=sqlConnection.Query<Book>(Query.Book.GetBook);
            return book;
        }
        public bool AddBook(List<Book> book)
        {            
            var result=sqlConnection.Execute(Query.Book.AddBook,book )>0;
            return result;
        }
    }
}