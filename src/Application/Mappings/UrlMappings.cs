namespace Application.Mappings;

public static class UrlMappings
{
    public static UrlEntity ToEntity(this UrlPostDto urlPostDTO)
        => new(0, urlPostDTO.Alias, urlPostDTO.Original);

    public static UrlDto ToDto(this UrlEntity urlEntity)
        => new(urlEntity.Id, urlEntity.Alias, urlEntity.Original);

    public static UrlEntity ToEntity(this UrlPutDto urlPutDto)
        => new(urlPutDto.Id, urlPutDto.Alias, urlPutDto.Original);

    public static IEnumerable<UrlDto> ToDto(this IEnumerable<UrlEntity> entities)
        => entities.Select(e => new UrlDto(e.Id, e.Alias, e.Original));
}
