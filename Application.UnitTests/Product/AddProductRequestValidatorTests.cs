using Application.Product.Add;

namespace Application.UnitTests.Product;

public class AddProductRequestValidatorTests
{
    private readonly AddProductRequestValidator _validator;

    public AddProductRequestValidatorTests()
    {
        _validator = new AddProductRequestValidator();
    }

    [Fact]
    public void Name_ShouldNotBeEmpty()
    {
        var request = new AddProductRequest { Name = "" };
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);

    }

    [Fact]
    public void Name_ShouldNotExceedMaximumLength()
    {
        var request = new AddProductRequest { Name = "EsteNombreEsDemasiadoLargo" };
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
    }

}