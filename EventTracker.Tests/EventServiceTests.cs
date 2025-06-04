using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using EventTracker.Data;
using EventTracker.Models;
using EventTracker.Services;

namespace EventTracker.Tests;

public class EventServiceTests
{
    private EventService _service = null!;
    private EventContext _context = null!;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<EventContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _context = new EventContext(options);
        _service = new EventService(_context);
    }

    [Test]
    public void SaveAsync_LocationNullOrEmpty_ThrowsException()
    {
        var model = new EventModel
        {
            Title = "Test",
            Date = DateTime.UtcNow,
            Location = ""
        };

        Assert.ThrowsAsync<ArgumentException>(async () => await _service.SaveAsync(model));
    }

    [Test]
    public async Task SaveAsync_ValidEvent_IncreasesCount()
    {
        var before = await _service.ListAsync();

        var model = new EventModel
        {
            Title = "Test",
            Date = DateTime.UtcNow,
            Location = "Ankara"
        };

        await _service.SaveAsync(model);

        var after = await _service.ListAsync();
        Assert.That(after.Count, Is.EqualTo(before.Count + 1));
    }
}
