namespace Application.Abstractions.Repository;

public interface IUrlRepository
{
    Task<UrlEntity> Post(UrlEntity entity);
}
