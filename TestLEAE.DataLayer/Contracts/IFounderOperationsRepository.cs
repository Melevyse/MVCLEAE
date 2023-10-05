namespace TestLEAE.DataLayer;
public interface IFounderOperationsRepository
{
    Task<Founder> GetFounderListByClientNameDb(
        string clientName);

    Task AddFounderAsyncDb(
        string Name,
        string Inn);
}

