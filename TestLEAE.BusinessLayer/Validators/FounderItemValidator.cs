using FluentValidation;
using TestLEAE.DataLayer;


namespace TestLEAE.BusinessLayer;
public class FounderItemValidator : AbstractValidator<Founder>
{
    public FounderItemValidator()
    {
        RuleFor(founder => founder.Inn)
            .NotEmpty()
            .InclusiveBetween(1000000000, 9999999999);

        RuleFor(founder => founder.Fio)
            .NotEmpty()
            .Matches(@"^[A-ZА-ЯЁ][a-zA-Zа-яёА-ЯЁ]+\s[A-ZА-ЯЁ][a-zA-Zа-яёА-ЯЁ]+\s[A-ZА-ЯЁ][a-zA-Zа-яёА-ЯЁ]+$");

        RuleFor(founder => founder.DateToAdd)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Today);

        RuleFor(founder => founder.DateToUpdate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Today);
    }
}

