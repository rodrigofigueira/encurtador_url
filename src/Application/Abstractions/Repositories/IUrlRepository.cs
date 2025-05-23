namespace Application.Abstractions.Repositories;

public interface IUrlRepository
{
    Task<UrlEntity> Post(UrlEntity entity);
    Task<bool> Put(UrlEntity entity);
}
