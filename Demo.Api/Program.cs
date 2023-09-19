using Demo.Api.Extensions;
using Demo.Api.Repo.Concrete;
using Demo.Api.Repo.Contract;
using Demo.Api.Service.Concrete;
using Demo.Api.Service.Contract;
using Microsoft.Extensions.Logging.Console;
using Serilog;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCustomeSwagger();
builder.Services.AddScoped<IDIDemoService, DIDemoService>();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddScoped<IWeatherForcastService, WeatherForcastService>();
builder.Services.AddScoped<IWeatherForcastRepository, WeatherForcastRepository>();
builder.Logging.AddMyLogger(builder);

var app = builder.Build();
app.Logger.LogInformation("Application is ready");
// Configure the HTTP request pipeline.
//app.UseHttpLogging();
app.UseStaticFiles();
app.UseCustomSwaggerMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();







#region Demo Api
//// Add services to the container.

//builder.Services.AddControllers();
//builder.Services.AddCustomeSwagger();
//builder.Services.AddScoped<IDIDemoService, DIDemoService>();
//builder.Services.AddScoped<IScopedService, ScopedService>();
//builder.Services.AddSingleton<ISingletonService, SingletonService>();
//builder.Services.AddTransient<ITransientService, TransientService>();
//var app = builder.Build();

//// Configure the HTTP request pipeline.
//app.UseStaticFiles();
//app.UseCustomSwaggerMiddleware();

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
#endregion
#region Understanding Middleware
//var app = builder.Build();
//app.Map("/Documentation", app =>
//{
//    app.Run(async context =>
//    {
//        await context.Response.WriteAsync("Map Test");
//    });
//});
//var logger = (ILogger<Program>)app.Services.GetService(typeof(ILogger<Program>))!;
//app.Use(async (context, next) =>
//{
//    logger.LogInformation("Before run");
//    await next.Invoke();
//    logger.LogInformation("After Run");
//});
//app.Run(async context =>
//{
//    logger.LogInformation("Executing Run");
//    await context.Response.WriteAsync("Hello from run ");
//});

//app.Run();
#endregion

