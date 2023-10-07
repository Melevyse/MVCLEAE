using FluentValidation;
using Microsoft.Extensions.Logging;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public class ClientOperationsService : IClientOperationsService
{
    private readonly IClientOperationsRepository _clientOperationsRepository;
    private readonly ILogger<ClientOperationsService> _logger;
    private readonly IValidator<Client> _validator;
    private readonly IValidationPrimitivesService _validationPrimitivesService;

    public ClientOperationsService(
        IClientOperationsRepository clientOperationsRepository,
        ILogger<ClientOperationsService> logger,
        IValidator<Client> validator,
        IValidationPrimitivesService validationPrimitivesService)
    {
        _clientOperationsRepository = clientOperationsRepository;
        _logger = logger;
        _validator = validator;
        _validationPrimitivesService = validationPrimitivesService;
    }

    public async Task AddClientAsync(
        Client client)
    {
        await _validator.ValidateAndThrowAsync(client);
        client.DateToAdd = DateTime.Today;
        client.DateToUpdate = DateTime.Today;
        await _clientOperationsRepository.AddClientAsyncDb(client);
    }
    public async Task<Client> GetClientByInn(
        long inn)
    {
        _validationPrimitivesService.BeValidInn(inn);
        var result = await _clientOperationsRepository.GetClientByInnDb(inn);
        return result;
    }

    public async Task<List<Client>> GetClientsListByType(
        ClientType type)
    {
        _validationPrimitivesService.BeValidClientType(type);
        var result = await _clientOperationsRepository.GetAllClientsByTypeDb(type);
        return result;
    }
}

