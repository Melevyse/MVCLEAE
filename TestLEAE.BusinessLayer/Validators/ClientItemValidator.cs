using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        RuleFor(client => client.Name)
            .NotEmpty()
            .Length(2, 45);

        RuleFor(client => client.Type)
            .IsInEnum();

        RuleFor(client => client.DateToAdd)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Today);

        RuleFor(client => client.DateToUpdate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Today);
    }
}
