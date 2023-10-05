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

    public async Task AddFounderAsync(string name, int inn)
    {
        await _founderOperationsRepository.AddFounderAsyncDb(name, inn);
    }

    public async Task<List<Founder>> GetFounderListByClientName(string clientName)
    {
        var result = await _founderOperationsRepository.GetFounderListByClientNameDb(clientName);
        return result;
    }
}

