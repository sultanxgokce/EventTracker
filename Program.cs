using Microsoft.EntityFrameworkCore;
using EventTracker.Data;
using Humanizer;
using EventTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add DbContext with SQLite
builder.Services.AddDbContext<EventContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var msg = DateTime.UtcNow.AddMinutes(-5).Humanize();
builder.Services.AddSingleton(new TimeMessage(msg));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Events}/{action=Index}/{id?}");


app.Run();
