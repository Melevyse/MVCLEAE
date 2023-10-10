using FluentValidation;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public class ClientItemValidator : AbstractValidator<Client>
{
    public ClientItemValidator()
    {
        RuleFor(client => client.Inn)
            .NotEmpty()
            .InclusiveBetween(1000000000, 9999999999);

        RuleFor(client => client.Type)
            .IsInEnum();

        RuleFor(client => client.DateToAdd)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Today);

        RuleFor(client => client.DateToUpdate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Today);

        When(client => client.Type == ClientType.LegalEntities, () =>
        {
            RuleFor(client => client.Name)
                .Length(2, 45);
        })
        .Otherwise(() =>
        {
            RuleFor(client => client.Name)
                .Matches(@"^[A-ZА-ЯЁ][a-zA-Zа-яёА-ЯЁ]+\s[A-ZА-ЯЁ][a-zA-Zа-яёА-ЯЁ]+\s[A-ZА-ЯЁ][a-zA-Zа-яёА-ЯЁ]+$");
        });
    }
}
