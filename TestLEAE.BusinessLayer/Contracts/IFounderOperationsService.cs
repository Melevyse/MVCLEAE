using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public interface IFounderOperationsService
{
    Task<Founder> GetFounderListByClientName(
        string clientName);

    Task AddFounderAsync(
        string Name,
        string Inn);
}

