using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public interface IValidationPrimitivesService
{
    void BeValidInn(long inn);

    void BeValidDateTime(DateTime date);

    void BeValidClientType(ClientType name);
}
