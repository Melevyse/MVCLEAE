namespace TestLEAE.DataLayer;
public interface IFounderOperationsRepository
{
    Task<List<Founder>> GetFounderListByClientInnDb(
        long inn);

    Task AddFounderAsyncDb(
        long clientInn,
        string fio,
        long Inn);
}

