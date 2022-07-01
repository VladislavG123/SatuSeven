using FluentValidation.TestHelper;
using SatuSeven.Gateways.ClientManagementSystem.Contracts.Parameters;
using SatuSeven.Gateways.ClientManagementSystem.Validators;
using Xunit;

namespace SatuSeven.Gateways.ClientManagementSystem.Tests.Validators;

public class CreateRequestToMakeCompanyParameterValidatorTests
{
    private readonly CreateRequestToMakeCompanyParameterValidator _validator;

    public CreateRequestToMakeCompanyParameterValidatorTests()
    {
        _validator = new CreateRequestToMakeCompanyParameterValidator();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("*****************************************************************************************************")]
    public void NameTestingValidation(string name)
    {
        _validator.TestValidate(new CreateRequestToMakeCompanyParameter
        {
            Name = name
        }).ShouldHaveValidationErrorFor(x => x.Name);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("*****************************************************************************************************" +
                "*****************************************************************************************************" +
                "*****************************************************************************************************" +
                "*****************************************************************************************************" +
                "*****************************************************************************************************")]
    public void DetailsTestingValidation(string details)
    {
        _validator.TestValidate(new CreateRequestToMakeCompanyParameter
        {
            Details = details
        }).ShouldHaveValidationErrorFor(x => x.Details);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("test")]
    [InlineData("google")]
    [InlineData("google.com")]
    [InlineData("ftp://google.com")]
    public void ImageUrlTestingValidation(string url)
    {
        _validator.TestValidate(new CreateRequestToMakeCompanyParameter
        {
            ImageUrl = url
        }).ShouldHaveValidationErrorFor(x => x.ImageUrl);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("AA")]
    [InlineData("test")]
    public void SlugTestingValidation(string slug)
    {
        _validator.TestValidate(new CreateRequestToMakeCompanyParameter
        {
            Slug = slug
        }).ShouldHaveValidationErrorFor(x => x.Slug);
    }
}