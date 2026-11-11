using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhotoNetwork.Data;
using PhotoNetwork.Data.Entities;
using PhotoNetwork.Data.Seeding;
using PhotoNetwork.Services.Storage;

var builder = WebApplication.CreateBuilder(args);

// Низът за връзка е в User Secrets, не в appsettings.json.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Home/Error";
});

// Снимките се пазят извън wwwroot, за да не се достъпват директно по URL.
builder.Services.AddSingleton<IFileStorage>(
    new LocalFileStorage(Path.Combine(builder.Environment.ContentRootPath, "App_Data", "uploads")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Прилага миграциите и създава ролите и демо потребителите.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await services.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();

    await DbSeeder.SeedAsync(
        services.GetRequiredService<RoleManager<IdentityRole>>(),
        services.GetRequiredService<UserManager<ApplicationUser>>(),
        app.Configuration["Seed:DemoPassword"]);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
