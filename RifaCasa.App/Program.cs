using RifaCasa.Data.EFCore;
using Microsoft.EntityFrameworkCore;
using RifaCasa.Services.Raffle;
using RifaCasa.Services.Buyer;
using RifaCasa.Controllers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));


builder.Services.AddScoped<IRaffleService, RaffleService>(); // Adiciona o serviço de RaffleService
builder.Services.AddScoped<IBuyerService, BuyerService>(); // Adiciona o serviço de BuyerService

builder.Services
    .AddControllersWithViews()
    .AddApplicationPart(typeof(PurchaseController).Assembly); // Adiciona o assembly do PurchaseController como parte da aplicação

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
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
