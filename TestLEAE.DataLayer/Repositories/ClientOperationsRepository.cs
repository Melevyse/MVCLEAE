using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace TestLEAE.DataLayer;

public class ClientOperationsRepository : IClientOperationsRepository
{
    private readonly SqlReportingContext _context;
    private readonly ILogger<ClientOperationsRepository> _logger;

    public ClientOperationsRepository(
        SqlReportingContext context,
        ILogger<ClientOperationsRepository> logger) 
    {
        _context = context;
        _logger = logger;
    }


}

