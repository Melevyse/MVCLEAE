using Microsoft.Extensions.Logging;

namespace TestLEAE.DataLayer;

public class FounderOperationsRepository : IFounderOperationsRepository
{
    private readonly SqlReportingContext _context;
    private readonly ILogger<FounderOperationsRepository> _logger;

    public FounderOperationsRepository(
        SqlReportingContext context, 
        ILogger<FounderOperationsRepository> logger)
    {
        _context = context;
        _logger = logger;
    }   


}


