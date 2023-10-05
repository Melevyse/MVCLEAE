using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public interface IFounderOperationsService
{
    Task<List<Founder>> GetFounderListByClientName(
        string clientName);

    Task AddFounderAsync(
        string clientName,
        string name,
        int inn);
}

