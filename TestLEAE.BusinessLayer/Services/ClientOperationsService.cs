using Microsoft.Extensions.Logging;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public class ClientOperationsService : IClientOperationsService
{
    private readonly IClientOperationsRepository _clientOperationsRepository;

    public ClientOperationsService(IClientOperationsRepository clientOperationsRepository)
    {
        _clientOperationsRepository = clientOperationsRepository;
    }
}

