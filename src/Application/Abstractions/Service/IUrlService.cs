namespace Application.Abstractions.Service;

public interface IUrlService
{
    Task<UrlDto> Post(UrlPostDto urlPostDto);
}
