using FluentValidation;

namespace ImparApp.Domain.Models.Validators
{
    public sealed class PhotoValidator : AbstractValidator<Photo>
    {
        public PhotoValidator()
        {
            RuleFor(x => x.Base64).NotEmpty();
        }
    }
}
