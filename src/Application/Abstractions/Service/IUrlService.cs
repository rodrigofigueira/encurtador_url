namespace Application.Abstractions.Service;

public interface IUrlService
{
    UrlEntity Post(UrlPostDto urlPostDto);
}
