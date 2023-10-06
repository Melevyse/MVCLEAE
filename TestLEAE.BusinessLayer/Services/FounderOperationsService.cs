namespace TestLEAE.BusinessLayer;

using System.Collections.Generic;
using System.Threading.Tasks;
using TestLEAE.DataLayer;

public class FounderOperationsService : IFounderOperationsService
{
    private readonly IFounderOperationsRepository _founderOperationsRepository;

    public FounderOperationsService(IFounderOperationsRepository founderOperationsRepository)
    {
        _founderOperationsRepository = founderOperationsRepository;
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

