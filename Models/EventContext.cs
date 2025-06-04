using Microsoft.EntityFrameworkCore;
using EventTracker.Models;

namespace EventTracker.Data;

public class EventContext : DbContext
{
    public EventContext(DbContextOptions<EventContext> options)
    : base(options) { }

    public DbSet<EventModel> Events { get; set; } // EventModel tablosunu temsil eden DbSet

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Varsayılan bazı etkinlik verilerini ekleyelim:
        modelBuilder.Entity<EventModel>().HasData(

            new EventModel
            {
                Id = 1,
                Title = "Örnek Etkinlik 1",
                Description = "ilk etkinlik için açıklama.",
                Date = new System.DateTime(2025, 01, 15, 14, 00, 00)
            },

            new EventModel
            {
                Id = 2,
                Title = "Örnek Etkinlik 2",
                Description = "ikinci etkinlik için açıklama.",
                Date = new System.DateTime(2025, 02, 20, 18, 30, 00)
            }





        );


    }




}