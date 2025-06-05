namespace Application.Services;

public class UrlService(IUrlRepository repository) : IUrlService
{
    public async Task<UrlDto> Post(UrlPostDto urlPostDto)
    {
        var postInserted = await repository.Post(urlPostDto.ToEntity());
        return postInserted.ToDto();
    }

    public async Task<bool> Put(UrlPutDto urlPutDto) => await repository.Put(urlPutDto.ToEntity());

    public async Task<bool> Delete(int id) => await repository.Delete(id);
}