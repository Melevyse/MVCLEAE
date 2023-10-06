namespace TestLEAE.DataLayer;
public interface IClientOperationsRepository
{
    Task<List<Client>> GetAllClientsDb();
    Task<Client> GetClientByInnDb(
        long inn);

    Task AddClientAsyncDb(
        string name,
        long inn,
        ClientType type);
}

