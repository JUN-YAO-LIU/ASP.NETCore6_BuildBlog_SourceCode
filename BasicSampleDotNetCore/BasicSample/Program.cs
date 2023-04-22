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

// Option �ﶵ
builder.Configuration
    .AddJsonFile(x => x.Path = "Configuration/TestOption.json");

builder.Services.Configure<TestJsonOption>(
    builder.Configuration.GetSection("JsonConfigTestOption"));

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(configurations.GetConnectionString("DbString")));

// �h�y�t
builder.Services.AddPortableObjectLocalization(options => options.ResourcesPath = "Localization");

string[] languages = { "en", "zh", "jp" };
builder.Services
    .Configure<RequestLocalizationOptions>(options => options
        .AddSupportedCultures(languages)
        .AddSupportedUICultures(languages));

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    // �h�y�t���U�A��
    .AddViewLocalization();

builder.Services.AddMvc();

#pragma warning disable CS0618
builder.Services.AddFluentValidation(options =>
  {
      options.ImplicitlyValidateChildProperties = true;
      options.ImplicitlyValidateRootCollectionElements = true;
      options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
  });
#pragma warning restore CS0618 // �����Φ����w�g�L��

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

// �h�y�tMiddleware
app.UseRequestLocalization();

// 2.Cors
app.UseCors("TestCorsPolicy");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

    // �j��ϥ�Hsts
    app.UseHsts();
}

// �۰���VHttps����
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