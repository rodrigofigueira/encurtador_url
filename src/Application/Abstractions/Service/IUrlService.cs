namespace Application.Abstractions.Service;

public interface IUrlService
{
    Task<UrlEntity> Post(UrlPostDto urlPostDto);
}
