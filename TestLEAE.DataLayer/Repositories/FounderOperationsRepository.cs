using Microsoft.EntityFrameworkCore;
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

    public async Task<List<Founder>> GetFounderListByClientNameDb(
        string clientName)
    {
        var client = await _context.Clients
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Name == clientName);
        List<Founder> founders = new List<Founder>();
        if (client != null)
        {
            founders = await _context.Founders
                .AsNoTracking()
                .Where(x => x.IdClient == client.Id)
                .ToListAsync();

            return founders;
        }
        else
        {
            return founders ?? throw new ArgumentException("No founders found in the database..");
        }
    }

    public async Task AddFounderAsyncDb(
        string name,
        int inn)
    {
        var founders = new Founder()
        {
            Fio = name,
            Inn = inn,
            DateToAdd = DateTime.Today,
            DateToUpdate = DateTime.Today
        };
        await _context.Founders.AddAsync(founders);
        await _context.SaveChangesAsync(); 
    }
}


