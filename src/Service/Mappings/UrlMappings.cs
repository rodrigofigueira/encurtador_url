namespace Service.Mappings;

public static class UrlMappings
{
    public static UrlEntity ToEntity(this UrlPostDto urlPostDTO)
    {
        return new(0, urlPostDTO.Alias, urlPostDTO.Original);
    }
}
