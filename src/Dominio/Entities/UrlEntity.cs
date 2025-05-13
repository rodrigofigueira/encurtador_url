namespace Domain.Entities;

public class UrlEntity(int id, string alias, string original)
{
    public int Id { get; } = id;
    public string Alias { get; } = alias;
    public string Original { get; } = original;
}
