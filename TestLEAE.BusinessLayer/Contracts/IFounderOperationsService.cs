using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public interface IFounderOperationsService
{
    Task<List<Founder>> GetFounderListByClientInn(
        long inn);

    Task AddFounderAsync(
        long clientInn,
        string fio,
        long inn);
}

