using FluentValidation;

namespace ImparApp.Domain.Models.Validators
{
    public class PhotoValidator : AbstractValidator<Photo>
    {
        public PhotoValidator()
        {
            RuleFor(x => x.Base64).NotEmpty();
        }
    }
}
