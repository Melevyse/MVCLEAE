using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

    public async Task<List<Client>> GetAllClientsDb() 
    {
        var clients = await _context.Clients.ToListAsync();

        if (clients == null || clients.Count == 0)
            throw new ArgumentException("No clients found in the database.");

        return clients;
    }
    public async Task<Client> GetClientByNameDb(
        string name)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(x => x.Name == name);
        return client ?? throw new ArgumentException("No client found in the database.");
    }


    public async Task AddClientAsyncDb(string name, 
        int inn, 
        ClientType type)
    {
        var client = new Client()
        {
            Name = name,
            Inn = inn,
            Type = type,
            DateToAdd = DateTime.Today,
            DateToUpdate = DateTime.Today
        };

        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }
}

