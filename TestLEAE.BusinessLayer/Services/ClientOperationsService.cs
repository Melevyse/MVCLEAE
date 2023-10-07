using Microsoft.Extensions.Logging;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public class ClientOperationsService : IClientOperationsService
{
    private readonly IClientOperationsRepository _clientOperationsRepository;
    private readonly ILogger<ClientOperationsService> _logger;

    public ClientOperationsService(
        IClientOperationsRepository clientOperationsRepository,
        ILogger<ClientOperationsService> logger)
    {
        _clientOperationsRepository = clientOperationsRepository;
        _logger = logger;
    }

    public async Task AddClientAsync(
        Client client)
    {
        client.DateToAdd = DateTime.Today;
        client.DateToUpdate = DateTime.Today;
        await _clientOperationsRepository.AddClientAsyncDb(client);
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

