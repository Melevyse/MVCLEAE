using FluentValidation;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public class ClientOperationsService : IClientOperationsService
{
    private readonly IClientOperationsRepository _clientOperationsRepository;
    private readonly IValidator<Client> _validator;
    private readonly IValidationPrimitivesService _validationPrimitivesService;

    public ClientOperationsService(
        IClientOperationsRepository clientOperationsRepository,
        IValidator<Client> validator,
        IValidationPrimitivesService validationPrimitivesService)
    {
        _clientOperationsRepository = clientOperationsRepository;
        _validator = validator;
        _validationPrimitivesService = validationPrimitivesService;
    }

    public async Task AddClientAsync(
        Client client)
    {
        client.DateToAdd = DateTime.Today;
        client.DateToUpdate = DateTime.Today;
        await _validator.ValidateAndThrowAsync(client);
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

