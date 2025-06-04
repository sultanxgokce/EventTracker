using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventTracker.Data;
using EventTracker.Models;

namespace EventTracker.Services;

public class EventService
{
    private readonly EventContext _context;

    public EventService(EventContext context)
    {
        _context = context;
    }

    public async Task<EventModel> SaveAsync(EventModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Location))
        {
            throw new ArgumentException("Location cannot be null or empty.", nameof(model));
        }
        _context.Events.Add(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<List<EventModel>> ListAsync()
    {
        return await _context.Events.ToListAsync();
    }
}
