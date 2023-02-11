using CompanyProject.Requests.CompanyRequestModels;
using FluentValidation;

namespace CompanyProject.Validations
{
    public class CompanyUpdateRequestValidator:AbstractValidator<CompanyUpdateRequest>
    {
        public CompanyUpdateRequestValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty()
                .WithMessage(" Company name should not be empty")
                .MinimumLength(3)
                .WithMessage("Name length should be ate least 3")
                .MaximumLength(50)
                .WithMessage("Name too large. Enter maximum 50 characters")
                .NotNull()
                .WithMessage("Company name should not be null");

            RuleFor(x => x.Location)
                .NotEmpty()
                .NotNull()
                .WithMessage("Location should be empty or null");

            RuleFor(x => x.Count)
                .NotEmpty()
                .WithMessage("Count cannot be empty")
                .GreaterThan(0)
                .WithMessage("Count must be positive");
        }
    }
}
