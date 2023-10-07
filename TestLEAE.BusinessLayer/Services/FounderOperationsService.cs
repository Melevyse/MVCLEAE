using AutoMapper;
using Microsoft.Extensions.Logging;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public class FounderOperationsService : IFounderOperationsService
{
    private readonly IFounderOperationsRepository _founderOperationsRepository;
    private readonly ILogger<FounderOperationsService> _logger;
    private readonly IMapper _mapper;

    public FounderOperationsService(
        IFounderOperationsRepository founderOperationsRepository,
        ILogger<FounderOperationsService> logger,
        IMapper mapper)
    {
        _founderOperationsRepository = founderOperationsRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task AddFounderAsync(
        long clientInn,
        string fio, 
        long inn)
    {
        await _founderOperationsRepository.AddFounderAsyncDb(clientInn, fio, inn);
    }

    public async Task<List<Founder>> GetFounderListByClientInn(
        long clientInn)
    {
        var result = await _founderOperationsRepository.GetFounderListByClientInnDb(clientInn);
        return result;
    }
}

