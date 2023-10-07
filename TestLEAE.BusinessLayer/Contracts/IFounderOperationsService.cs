using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public interface IFounderOperationsService
{
    Task<List<Founder>> GetFounderListByClientInn(
        long inn);

    Task AddFounderAsync(
        Founder founder,
        long  innClient);
}

