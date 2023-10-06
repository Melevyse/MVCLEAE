namespace TestLEAE.DataLayer;
public interface IClientOperationsRepository
{
    Task<List<Client>> GetAllClientsByTypeDb(
        ClientType type);
    Task<Client> GetClientByInnDb(
        long inn);

    Task AddClientAsyncDb(
        string name,
        long inn,
        ClientType type);
}

