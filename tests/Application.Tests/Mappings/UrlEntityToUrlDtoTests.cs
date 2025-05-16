namespace Application.Tests.Mappings;

public class UrlEntityToUrlDtoTests
{
    [Fact]
    public void With_Valid_Value_Returns_Dto()
    {
        //arrange
        UrlEntity urlEntity = new(1, "alias", "original");

        //act
        var urlDto = urlEntity.ToDto();

        //assert
        Assert.IsType<UrlDto>(urlDto);
        Assert.Equal(urlEntity.Id, urlDto.Id);
        Assert.Equal(urlEntity.Alias, urlDto.Alias);
        Assert.Equal(urlEntity.Original, urlDto.Original);
    }
}
