using Microsoft.EntityFrameworkCore;
using Domain.Data;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.Extensions.Configuration;

//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.
//This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the GNU General Public License for more details.
//You should have received a copy of the GNU General Public License along with this program.If not, see<https://www.gnu.org/licenses/>.

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
