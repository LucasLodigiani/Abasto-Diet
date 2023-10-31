using Infraestructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Infraestructure.UnitTests.Services;

public class FileServiceTests
{
    [Fact]
    public async Task ShouldSaveImage()
    {
        var fileMock = new Mock<IFormFile>();
        fileMock.Setup(x => x.FileName).Returns("TEST.jpg");
        fileMock.Setup(x => x.Length).Returns(1024);

        var envMock = new Mock<IWebHostEnvironment>();
        envMock.Setup(x => x.ContentRootPath).Returns("somepath");

        var fileService = new FileService(envMock.Object);

        // Act
        var fileNameResult = await fileService.SaveImageAsync(fileMock.Object);

        // Assert
        string expectedFilePath = Path.Combine(envMock.Object.ContentRootPath, "Media", fileNameResult);
        Assert.True(File.Exists(expectedFilePath), "La imagen no se guardo en la ruta esperada");

    }
}