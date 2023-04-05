using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppGCT.Data;
using Microsoft.AspNetCore.Identity;
using AppGCT.Areas.Identity.Data;
using AppGCT;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppGCTContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppGCTContext") ?? throw new InvalidOperationException("Connection string 'AppGCTContext' not found.")));

builder.Services.AddDefaultIdentity<Utilizador>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppGCTContext>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
