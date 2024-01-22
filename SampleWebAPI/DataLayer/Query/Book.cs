namespace Sample.Data.Query
{
    public class Book{
    public const string GetBook = @"Select name Name,title Title,author Author from Book";
    public const string AddBook = @"Insert into Book values(@name,@title,@author)";
    }

}
