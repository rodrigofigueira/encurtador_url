namespace Application.Tests;

public class UrlPostDtoToEntityTests
{
    [Fact]
    public void With_Valid_Value_Returns_Entity()
    {
        //arrange
        string ALIAS = @"http://abc.curto.com";
        string ORIGINAL = @"http://www.enderecocompleto.com";
        UrlPostDto urlPostDto = new(ALIAS, ORIGINAL);

        //act
        UrlEntity urlEntity = urlPostDto.ToEntity();

        //assert
        Assert.Equal(ALIAS, urlEntity.Alias);
        Assert.Equal(ORIGINAL, urlEntity.Original);
        Assert.Equal(0, urlEntity.Id);
    }
}
