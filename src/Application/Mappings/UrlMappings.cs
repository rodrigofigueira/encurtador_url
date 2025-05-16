namespace Application.Mappings;

public static class UrlMappings
{
    public static UrlEntity ToEntity(this UrlPostDto urlPostDTO)
        => new(0, urlPostDTO.Alias, urlPostDTO.Original);

    public static UrlDto ToDto(this UrlEntity urlEntity) =>
        new(urlEntity.Id, urlEntity.Alias, urlEntity.Original);
}
