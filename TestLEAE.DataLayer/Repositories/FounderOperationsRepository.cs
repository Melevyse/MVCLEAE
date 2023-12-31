﻿using Microsoft.EntityFrameworkCore;

namespace TestLEAE.DataLayer;

public class FounderOperationsRepository : IFounderOperationsRepository
{
    private readonly SqlReportingContext _context;

    public FounderOperationsRepository(
        SqlReportingContext context)
    {
        _context = context;
    }

    public async Task<List<Founder>> GetFounderListByClientInnDb(
        long clientInn)
    {
        var client = await _context.Clients
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Inn == clientInn);
        var founders = new List<Founder>();
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
        Founder founder,
        long innClient)
    {
        var client = await _context.Clients
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Inn == innClient && 
                             x.Type == ClientType.LegalEntities);
        if (client != null)
        {
            founder.IdClient = client.Id;
            await _context.Founders.AddAsync(founder);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("No client found in the database..");
        }
    }
}


