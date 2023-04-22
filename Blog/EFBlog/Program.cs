using EFBlog.Applications.ArticleService;
using EFBlog.Applications.Auth;
using EFBlog.DbAccess;
using EFBlog.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configurations = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(configurations.GetConnectionString("DbString")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Http存取器
builder.Services.AddHttpContextAccessor();

// 註冊客製化介面

builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services
    .AddAuthentication(options => options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = new PathString("/Login");
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();