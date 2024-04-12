using Microsoft.EntityFrameworkCore;
using Domain.Data;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SecurityDb>(options =>
    options.UseSqlServer(
        connectionString,
        x => x.MigrationsAssembly("Security Webapp")
    )
);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(); // Add this line

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
