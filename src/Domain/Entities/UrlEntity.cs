namespace Domain.Entities;

public class UrlEntity(int id, string alias, string original)
{
    public int Id { get; set; } = id;
    public string Alias { get; set; } = alias;
    public string Original { get; set; } = original;
}
