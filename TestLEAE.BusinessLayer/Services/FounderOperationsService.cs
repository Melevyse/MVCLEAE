using FluentValidation;
using Microsoft.Extensions.Logging;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public class FounderOperationsService : IFounderOperationsService
{
    private readonly IFounderOperationsRepository _founderOperationsRepository;
    private readonly ILogger<FounderOperationsService> _logger;
    private readonly IValidator<Founder> _validator;
    private readonly IValidationPrimitivesService _validationPrimitivesService;

    public FounderOperationsService(
        IFounderOperationsRepository founderOperationsRepository,
        ILogger<FounderOperationsService> logger,
        IValidator<Founder> validator,
        IValidationPrimitivesService validationPrimitivesService
        )
    {
        _founderOperationsRepository = founderOperationsRepository;
        _logger = logger;
        _validator = validator;
        _validationPrimitivesService = validationPrimitivesService;
    }

    public async Task AddFounderAsync(
        Founder founder,
        long innClient)
    {
        founder.DateToAdd = DateTime.Today;
        founder.DateToUpdate = DateTime.Today;
        await _validator.ValidateAndThrowAsync(founder);
        _validationPrimitivesService.BeValidInn(innClient);
        await _founderOperationsRepository.AddFounderAsyncDb(founder, innClient);
    }

    public async Task<List<Founder>> GetFounderListByClientInn(
        long clientInn)
    {
        _validationPrimitivesService.BeValidInn(clientInn);
        var result = await _founderOperationsRepository.GetFounderListByClientInnDb(clientInn);
        return result;
    }
}

