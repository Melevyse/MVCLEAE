using Microsoft.Extensions.Logging;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public class FounderOperationsService : IFounderOperationsService
{
    private readonly IFounderOperationsRepository _founderOperationsRepository;
    private readonly ILogger<FounderOperationsService> _logger;

    public FounderOperationsService(
        IFounderOperationsRepository founderOperationsRepository,
        ILogger<FounderOperationsService> logger)
    {
        _founderOperationsRepository = founderOperationsRepository;
        _logger = logger;
    }

    public async Task AddFounderAsync(
        Founder founder,
        long innClient)
    {
        founder.DateToAdd = DateTime.Today;
        founder.DateToUpdate = DateTime.Today;
        await _founderOperationsRepository.AddFounderAsyncDb(founder, innClient);
    }

    public async Task<List<Founder>> GetFounderListByClientInn(
        long clientInn)
    {
        var result = await _founderOperationsRepository.GetFounderListByClientInnDb(clientInn);
        return result;
    }
}

