using Microsoft.EntityFrameworkCore;

namespace TestLEAE.DataLayer;

public class ClientOperationsRepository : IClientOperationsRepository
{
    private readonly SqlReportingContext _context;

    public ClientOperationsRepository(
        SqlReportingContext context) 
    {
        _context = context;
    }

    public async Task<List<Client>> GetAllClientsByTypeDb(
        ClientType type) 
    {
        var clients = await _context.Clients
            .AsNoTracking()
            .Where(x => x.Type == type)
            .ToListAsync();

        if (clients == null || clients.Count == 0)
            throw new ArgumentException("No clients found in the database.");

        return clients;
    }
    public async Task<Client> GetClientByInnDb(
        long inn)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(x => x.Inn == inn);
        return client ?? throw new ArgumentException("No client found in the database.");
    }

    public async Task AddClientAsyncDb(
        Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }
}

