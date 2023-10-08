using FluentValidation;
using Microsoft.Extensions.Logging;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public class ValidationPrimitivesService : IValidationPrimitivesService
{
    ILogger<FounderOperationsService> _logger;

    public ValidationPrimitivesService(
        ILogger<FounderOperationsService> logger)
    {
        _logger = logger;
    }

    public void BeValidInn(long inn)
    {
        if (inn < 1000000000 || inn > 9999999999)
            throw new ArgumentException("Invalid inn value");
    }


    public void BeValidDateTime(DateTime date)
    {
        if (date > DateTime.Now)
            throw new ArgumentException("Invalid DateTime");
    }

    public void BeValidClientType(ClientType type)
    {
        if (!Enum.IsDefined(typeof(ClientType), type))
            throw new ArgumentException("Invalid client type");
    }
}
