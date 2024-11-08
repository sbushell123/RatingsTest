namespace Ratings.API.DataProviders
{
    public interface IDataProvider<T>
    {
        Task<T> Get();
    }
}