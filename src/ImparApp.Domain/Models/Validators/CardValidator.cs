using FluentValidation;

namespace ImparApp.Domain.Models.Validators
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(e => e.PhotoId).NotEmpty().When(e => e.Photo is null);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Status).NotEmpty().MaximumLength(100);
        }
    }
}
