using System;
using NUnit.Framework;
using EventTracker.Models;

namespace EventTracker.Tests;

public class EventModelTests
{
    [Test]
    public void IsPast_ReturnsTrue_WhenDateInPast()
    {
        var model = new EventModel { Date = DateTime.Now.AddDays(-1) };
        Assert.That(model.IsPast, Is.True);
    }

    [Test]
    public void IsPast_ReturnsFalse_WhenDateInFuture()
    {
        var model = new EventModel { Date = DateTime.Now.AddDays(1) };
        Assert.That(model.IsPast, Is.False);
    }
}
