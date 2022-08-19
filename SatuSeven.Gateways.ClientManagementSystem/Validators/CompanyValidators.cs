using FluentValidation;
using SatuSeven.Gateways.ClientManagementSystem.Contracts.Parameters;

namespace SatuSeven.Gateways.ClientManagementSystem.Validators;

public class CreateRequestToMakeCompanyParameterValidator : AbstractValidator<CreateRequestToMakeCompanyParameter>
{
    public CreateRequestToMakeCompanyParameterValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(100);
        
        RuleFor(p => p.Details)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(500);
        
        RuleFor(p => p.LogoUrl)
            .NotEmpty()
            .Must(LinkMustBeAUri)
            .WithMessage("Link '{PropertyValue}' must be a valid URI. eg: http://www.SomeWebSite.com.au");

        RuleFor(p => p.Slug)
            .NotEmpty()
            .Length(3);
    }
    
    private static bool LinkMustBeAUri(string? link)
    {
        if (string.IsNullOrWhiteSpace(link))
        {
            return false;
        }

        return Uri.TryCreate(link, UriKind.Absolute, out var outUri)
               && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
    }
}