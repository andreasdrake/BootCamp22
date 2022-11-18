using FluentValidation;
using HackerService.Api.Models;

namespace HackerService.Api.Validators;
public class DecryptRequestValidator : AbstractValidator<DecryptRequest>
{
	public DecryptRequestValidator()
	{
		RuleFor(m => m)
			.NotNull();

		RuleFor(m => m.Value)
			.NotNull()
			.NotEmpty()			
			.WithMessage("Value must not be null or empty string");
	}
}
