namespace Application.Tests.Mappings;

public class UrlPutDtoToEntityTests
{
    [Fact]
    public void With_Valid_Value_Returns_Entity()
    {
        //arrange
        int ID = 1;
        string ALIAS = @"http://abc.curto.com";
        string ORIGINAL = @"http://www.enderecocompleto.com";
        UrlPutDto urlPutDto = new(ID, ALIAS, ORIGINAL);

        //act
        UrlEntity urlEntity = urlPutDto.ToEntity();

        //assert
        Assert.Equal(ALIAS, urlEntity.Alias);
        Assert.Equal(ORIGINAL, urlEntity.Original);
        Assert.Equal(ID, urlEntity.Id);
    }
}
