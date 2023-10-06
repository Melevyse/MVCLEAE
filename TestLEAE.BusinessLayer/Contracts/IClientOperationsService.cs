using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public interface IClientOperationsService
{
    Task<List<Client>> GetClientsListByType(
        ClientType type);
    Task<Client> GetClientByInn(
        long inn);

    Task AddClientAsync(
        string name,
        long inn,
        ClientType type);
}
