using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public interface IClientOperationsService
{
    Task<List<Client>> GetClientsList();
    Task<Client> GetClientByName(
        string name);

    Task AddClientAsync(
        string name,
        int inn,
        string type);
}
