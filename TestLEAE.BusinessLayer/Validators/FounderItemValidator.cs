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
            .Length(2, 45);

        RuleFor(founder => founder.DateToAdd)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Now);

        RuleFor(founder => founder.DateToUpdate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Now);
    }
}

