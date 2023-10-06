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

    public async Task AddClientAsync(
        string name, 
        long inn, 
        ClientType type)
    {
        await _clientOperationsRepository.AddClientAsyncDb(name, inn, type);
    }
    public async Task<Client> GetClientByInn(
        long inn)
    {
        var result = await _clientOperationsRepository.GetClientByInnDb(inn);
        return result;
    }

    public async Task<List<Client>> GetClientsListByType(
        ClientType type)
    {
        var result = await _clientOperationsRepository.GetAllClientsByTypeDb(type);
        return result;
    }
}

