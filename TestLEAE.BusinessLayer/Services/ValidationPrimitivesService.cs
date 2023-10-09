using FluentValidation;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public class ValidationPrimitivesService : IValidationPrimitivesService
{
    public void BeValidInn(long inn)
    {
        if (inn < 1000000000 || inn > 9999999999)
            throw new ValidationException("Invalid inn value");
    }


    public void BeValidDateTime(DateTime date)
    {
        if (date > DateTime.Today)
            throw new ValidationException("Invalid DateTime");
    }

    public void BeValidClientType(ClientType type)
    {
        if (!Enum.IsDefined(typeof(ClientType), type))
            throw new ValidationException("Invalid client type");
    }
}
