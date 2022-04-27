
namespace DataAccessLibrary.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionID="Default");
        Task SaveData<T>(string sql, T parameters, string connectionID="Default");
    }
}