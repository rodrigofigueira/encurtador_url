namespace Application.Tests.Services;

public class UrlServiceTests
{
    [Fact]
    public async void Post_With_Valid_Values_Returns_Inserted_Object()
    {
        //arrange
        var mockRepository = new Mock<IUrlRepository>();
        mockRepository.Setup(r => r.Post(It.IsAny<UrlEntity>()))
                      .ReturnsAsync((UrlEntity u) => new UrlEntity(1, u.Alias, u.Original));

        UrlService service = new(mockRepository.Object);
        UrlPostDto urlPostDto = new(@"http://teste.com", @"http://completa.com.br");

        //act
        var urlInserted = await service.Post(urlPostDto);

        //assert
        Assert.Equal(1, urlInserted.Id);
        Assert.Equal(urlPostDto.Original, urlInserted.Original);
        Assert.Equal(urlPostDto.Alias, urlInserted.Alias);
    }

    [Fact]
    public async void Put_With_Valid_Values_Returns_True()
    {
        //arrange
        var mockRepository = new Mock<IUrlRepository>();
        mockRepository.Setup(r => r.Put(It.IsAny<UrlEntity>()))
                      .ReturnsAsync(() => true);

        UrlService service = new(mockRepository.Object);
        UrlPutDto urlPutDto = new(1, @"http://teste.com", @"http://completa.com.br");

        //act
        var urlWasUpdated = await service.Put(urlPutDto);

        //assert
        Assert.True(urlWasUpdated);
    }

    [Fact]
    public async void Delete_With_Valid_Id_Returns_True()
    {
        //arrange
        var mockRepository = new Mock<IUrlRepository>();
        mockRepository.Setup(r => r.Delete(It.IsAny<int>()))
                      .ReturnsAsync(() => true);

        UrlService service = new(mockRepository.Object);
        //act
        var urlWasDeleted = await service.Delete(1);

        //assert
        Assert.True(urlWasDeleted);
    }

}
