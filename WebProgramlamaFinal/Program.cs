using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
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
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICountryService,CountryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IEndpointServices, EndpointServices>();
builder.Services.AddScoped<ICityServices,CityServices>();
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
    pattern: "{controller=Product}/{action=PublicList}");
app.UseStatusCodePagesWithReExecute("/Home/NotFoundPage");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var endpointService = services.GetRequiredService<IEndpointServices>();

    // Web projesinin kendi assembly bilgisini servise gönderiyoruz!
    await endpointService.SeedEndpointsAsync(Assembly.GetExecutingAssembly());
}
app.Run();
