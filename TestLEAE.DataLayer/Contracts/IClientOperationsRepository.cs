namespace TestLEAE.DataLayer;
public interface IClientOperationsRepository
{
    Task<List<Client>> GetAllClientsDb();
    Task<Client> GetClientByNameDb(
        string name);

    Task AddClientAsyncDb(
        string name,
        string inn,
        string type);
}

