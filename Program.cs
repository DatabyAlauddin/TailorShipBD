using Microsoft.EntityFrameworkCore;
using TylorShop.Models;
using TylorShop.Models_Customs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<FieldTranslationService>();

// Add Session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configure database context
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<AppDbContext>(item => item.UseSqlServer(config.GetConnectionString("DBConnection")));


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(180); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();
app.Urls.Add($"http://*:{Environment.GetEnvironmentVariable("PORT") ?? "5000"}");



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
    context.Response.Headers.Add("Pragma", "no-cache");
    context.Response.Headers.Add("Expires", "0");
    await next();
});




app.Use(async (context, next) =>
{
    var path = context.Request.Path.ToString().ToLower();

    // Allow access to Login and Authenticate actions without redirection
    if (!path.Contains("/permissionpolicyusers/login") &&
        !path.Contains("/permissionpolicyusers/authenticate") &&
        context.Session.GetString("UserName") == null)
    {
        context.Response.Redirect("/PermissionPolicyUsers/Login");
        return;
    }

    await next();
});

app.MapControllers();

// Map default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/");

app.Run();



app.Run();
