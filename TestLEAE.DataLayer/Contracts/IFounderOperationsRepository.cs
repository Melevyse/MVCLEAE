namespace TestLEAE.DataLayer;
public interface IFounderOperationsRepository
{
    Task<List<Founder>> GetFounderListByClientInnDb(
        long inn);

    Task AddFounderAsyncDb(
        Founder founder,
        long innClient);
}

