namespace Application.Abstractions.Repositories;

public interface IUrlRepository
{
    Task<UrlEntity> Post(UrlEntity entity);
    Task<bool> Put(UrlEntity entity);
    Task<bool> Delete(int id);
    Task<UrlEntity> Get(int id);
    Task<IEnumerable<UrlEntity>> Get(int pageNumber, int pageSize);
    Task<int> Count();
}
