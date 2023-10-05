using Microsoft.Extensions.Logging;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public class ClientOperationsService : IClientOperationsService
{
    private readonly IClientOperationsRepository _clientOperationsRepository;

    public ClientOperationsService(IClientOperationsRepository clientOperationsRepository)
    {
        _clientOperationsRepository = clientOperationsRepository;
    }

    public async Task AddClientAsync(string name, int inn, string type)
    {
        if (Enum.TryParse<ClientType>(type, out var clientType))
        {
            await _clientOperationsRepository.AddClientAsyncDb(name, inn, clientType);
        }
        else
        {
            throw new ArgumentException("Invalid ClientType value.");
        }
    }
    public async Task<Client> GetClientByName(string name)
    {
        var result = await _clientOperationsRepository.GetClientByNameDb(name);
        return result;
    }

    public async Task<List<Client>> GetClientsList()
    {
        var result = await _clientOperationsRepository.GetAllClientsDb();
        return result;
    }
}

