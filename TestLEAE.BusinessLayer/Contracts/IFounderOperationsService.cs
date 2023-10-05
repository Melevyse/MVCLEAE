using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public interface IFounderOperationsService
{
    Task<List<Founder>> GetFounderListByClientName(
        string clientName);

    Task AddFounderAsync(
        string name,
        int inn);
}

