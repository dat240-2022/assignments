using System;
using System.Globalization;
using System.IO;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UiS.Dat240.Lab3;
using UiS.Dat240.Lab3.Infrastructure.Data;
using UiS.Dat240.Lab3.SharedKernel;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60); // We're keeping this low to facilitate testing. Would normally be higher. Default is 20 minutes
    options.Cookie.IsEssential = true;              // Otherwise we need cookie approval
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<ShopContext>(options =>
{
    options.UseSqlite($"Data Source={Path.Combine("Infrastructure", "Data", "shop.db")}");
});

builder.Services.AddMediatR(typeof(Program));

builder.Services.Scan(scan => scan
    .FromCallingAssembly()
        .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
        .AsImplementedInterfaces());

builder.Services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    if (app.Environment.IsDevelopment())
    {
        var db = scope.ServiceProvider.GetRequiredService<ShopContext>();
        if (!db.FoodItems.Any())
        {
            FakeData.Init();
            db.FoodItems.AddRange(FakeData.FoodItems);
            db.SaveChanges();
        }
    }
}

app.UseHttpsRedirection();

var supportedCultures = new[]
{
            new CultureInfo("en-GB"),
        };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-GB"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.UseSession();

app.MapRazorPages();


app.Run();

public partial class Program { }
