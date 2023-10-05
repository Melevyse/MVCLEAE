namespace TestLEAE.BusinessLayer;
using TestLEAE.DataLayer;

public class FounderOperationsService : IFounderOperationsService
{
    private readonly IFounderOperationsRepository _repository;

    public FounderOperationsService(IFounderOperationsRepository repository)
    {
        _repository = repository;
    }   
}

