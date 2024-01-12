using System.Data.SqlClient;

namespace Book.Data.Interface
{
    public interface IDALBase
    {
    public SqlConnection Connect();
    }
}