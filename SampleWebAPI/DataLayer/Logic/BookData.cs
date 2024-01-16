namespace Book.Data.Logic{
    using System.Collections;
    using Book.Model;
    using Book.Data.Interface;
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
            var book=sqlConnection.Query<Book>("Select * from Book");
            return book;
        }
        public bool AddBook(List<Book> book)
        {            
            var result=sqlConnection.Execute("Insert into Book values(@name,@title,@author)",book )>0;
            return result;
        }
    }
}