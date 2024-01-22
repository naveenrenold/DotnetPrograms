using System.Data.SqlClient;

namespace Sample.Data.Interface
{
    public interface IDALBase
    {
    public SqlConnection Connect();
    }
}