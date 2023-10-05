namespace TestLEAE.DataLayer;
public interface IFounderOperationsRepository
{
    Task<List<Founder>> GetFounderListByClientNameDb(
        string clientName);

    Task AddFounderAsyncDb(
        string name,
        int Inn);
}

