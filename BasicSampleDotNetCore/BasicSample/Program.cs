using BasicSample.Application;
using BasicSample.DbAccess;
using BasicSample.Options;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// builder.Logging.AddFile($"{Directory.GetCurrentDirectory()}\\Logs\\log.txt");

var configurations = builder.Configuration;

//builder.Configuration
//    .AddIniFile(x => x.Path = "Configuration/TestINI.ini");

//builder.Configuration
//    .AddXmlFile(x => x.Path = "Configuration/TestXML.xml");

builder.Configuration
    .AddJsonFile(x => x.Path = "Configuration/TestJson.json");

// Option 選項
builder.Configuration
    .AddJsonFile(x => x.Path = "Configuration/TestOption.json");

builder.Services.Configure<TestJsonOption>(
    builder.Configuration.GetSection("JsonConfigTestOption"));

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(configurations.GetConnectionString("DbString")));

// 多語系
builder.Services.AddPortableObjectLocalization(options => options.ResourcesPath = "Localization");

string[] languages = { "en", "zh", "jp" };
builder.Services
    .Configure<RequestLocalizationOptions>(options => options
        .AddSupportedCultures(languages)
        .AddSupportedUICultures(languages));

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    // 多語系註冊服務
    .AddViewLocalization();

builder.Services.AddMvc();

#pragma warning disable CS0618
builder.Services.AddFluentValidation(options =>
  {
      options.ImplicitlyValidateChildProperties = true;
      options.ImplicitlyValidateRootCollectionElements = true;
      options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
  });
#pragma warning restore CS0618 // 類型或成員已經過時

// 1.Cors
string[] corsParameter = { "http://test.com", "https://test.com" };
builder.Services.AddCors(opt =>
    opt.AddPolicy("TestCorsPolicy", policy =>
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins(corsParameter)));

builder.Services.AddTransient<ICarService, CarService>();

var app = builder.Build();

// 多語系Middleware
app.UseRequestLocalization();

// 2.Cors
app.UseCors("TestCorsPolicy");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

    // 強制使用Hsts
    app.UseHsts();
}

// 自動轉向Https網頁
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// MapRazorPages
// MapBlazorHub
app.MapControllerRoute(
    name: "Multi",
    pattern: "test/{*article}",
    defaults: new { controller = "Multi", action = "Article" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();