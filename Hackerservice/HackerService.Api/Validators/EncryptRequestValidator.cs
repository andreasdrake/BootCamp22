using FluentValidation;
using HackerService.Api.Models;

namespace HackerService.Api.Validators
{
    public class EncryptRequestValidator:AbstractValidator<EncryptRequest>
    {
        public EncryptRequestValidator()
        {
            RuleFor(m => m)
            .NotNull();

            RuleFor(m => m.Value)
                .NotNull()
                .NotEmpty()
                .WithMessage("Value must not be null or empty string");
        }
    }
}
