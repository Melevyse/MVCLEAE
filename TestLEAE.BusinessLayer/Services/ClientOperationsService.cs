using AutoMapper;
using Microsoft.Extensions.Logging;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public class ClientOperationsService : IClientOperationsService
{
    private readonly IClientOperationsRepository _clientOperationsRepository;
    private readonly ILogger<ClientOperationsService> _logger;
    private readonly IMapper _mapper;

    public ClientOperationsService(
        IClientOperationsRepository clientOperationsRepository,
        ILogger<ClientOperationsService> logger,
        IMapper mapper)
    {
        _clientOperationsRepository = clientOperationsRepository;
        _logger = logger;
        _mapper = mapper;
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

