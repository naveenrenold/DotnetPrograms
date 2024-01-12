namespace Book.Data.Logic
{
    using System.Data.SqlClient;
    using System.Configuration;
    using Book.Data.Interface;

    public class DALBase:IDALBase
{
    public readonly IConfiguration iconfig;
    public DALBase(IConfiguration iconfig)
    {
        this.iconfig=iconfig;
    }
    public SqlConnection Connect()
    {
        string connectionString = this.iconfig.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");        
        try
        {
        var conn=new SqlConnection(connectionString);
        return conn;        
        }
        catch(SqlException ex)
        {
            System.Console.WriteLine(ex.StackTrace);
            throw;
        }                
    }
}

}