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

    [Fact]
    public void ToDto_DeveConverterListaDeUrlEntityParaUrlDtoCorretamente()
    {
        // Arrange
        UrlEntity url1 = new(1, "abc", "https://original.com/abc");
        UrlEntity url2 = new(2, "xyz", "https://original.com/xyz");

        var entities = new List<UrlEntity> { url1, url2 };

        // Act
        var dtos = entities.ToDto().ToList();

        // Assert
        Assert.NotNull(dtos);
        Assert.Equal(2, dtos.Count);
        Assert.Equivalent(url1, dtos[0]);
        Assert.Equivalent(url2, dtos[1]);
    }
}
