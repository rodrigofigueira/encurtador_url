namespace Application.Services;

public class UrlService(IUrlRepository repository) : IUrlService
{
    public async Task<UrlEntity> Post(UrlPostDto urlPostDto) => await repository.Post(urlPostDto.ToEntity());

}
