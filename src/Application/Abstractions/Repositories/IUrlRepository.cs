namespace Application.Abstractions.Repositories;

public interface IUrlRepository
{
    Task<UrlEntity> Post(UrlEntity entity);
}
