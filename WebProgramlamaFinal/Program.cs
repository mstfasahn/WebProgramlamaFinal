using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WPF.Data;
using WPF.Models.Dtos.MappingProfiles;
using WPF.MVC.Filters;
using WPF.Services.Contracts;
using WPF.Services.Implementations;
using WPF.Services.Services;
var builder = WebApplication.CreateBuilder(args);
var ConnectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(ConnectionStrings));
builder.Services.AddAutoMapper(typeof(CarrierProfiles));
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//DI    
builder.Services.AddScoped<ICarrierService, CarrierService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddTransient<IUserLogginService, UserLogginService>();
builder.Services.AddScoped<PermissionControlAttribute>();
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
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Carrier}/{action=List}");

app.Run();
