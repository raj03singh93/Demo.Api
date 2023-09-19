using Demo.Api.Constants;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Demo.Api.Extensions
{
    public static class AppExtention
    {
        public static IServiceCollection AddCustomeSwagger(this IServiceCollection services)
        {
            // Swagger generator that builds SwaggerDocument objects directly from your routes, controllers, and models.
            // It's typically combined with the Swagger endpoint middleware to automatically expose Swagger JSON.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("Demo.api", new()
                {
                    Version = "v1",
                    Title = "Demo Api",
                    Description = " Demo Description",
                    TermsOfService = new("http://Test.com"),
                    Contact = new()
                    {
                        Name = "Raj",
                        Url = new("http://test.com"),
                        Email = "raj@gmail.com"
                    },
                    License = new()
                    {
                        Name = "License",
                        Url = new("http://test.com")
                    }
                });
                var xmlFilePath = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilePath));
                opt.AddSwaggerAuthentication();
            }); 
            return services;
        }

        public static void AddMyLogger(this ILoggingBuilder logging, WebApplicationBuilder builder)
        {
            #region 
            // Hrded code loglevel
            //builder.Logging.AddFilter<ConsoleLoggerProvider>("Microsoft", LogLevel.Warning);

            //// Hard Codded
            //var hardCodedLogger = new LoggerConfiguration()
            //    .MinimumLevel.Information()
            //    .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning)
            //    .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
            //    .WriteTo.Console()
            //    .WriteTo.File(path: "./DemoApilog-.txt", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();
            //builder.Logging.ClearProviders();
            #endregion

            // Added Serilog from file
            var fromFile = new LoggerConfiguration()
                            .ReadFrom.Configuration(builder.Configuration)
                            .CreateLogger();


            logging.AddSerilog(fromFile);
            Serilog.Debugging.SelfLog.Enable(msg =>
            {
                Debug.Print(msg);
                Debugger.Break();
            }); 
        }

        static void AddSwaggerAuthentication(this Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions opt)
        {
            opt.AddSecurityDefinition(BasicAuthenticationDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
            {
                Name = "Basic Authentication",
                Description = "Basic authentication with user and password.",
                In = ParameterLocation.Header,
                Scheme = BasicAuthenticationDefaults.AuthenticationScheme,
                Type = SecuritySchemeType.ApiKey
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme()
                            {
                                Reference = new OpenApiReference()
                                {
                                    Id = BasicAuthenticationDefaults.AuthenticationScheme,
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            new string[] { }
                        }
                    });
        }
    }

    public static class AppExtension
    {
        public static WebApplication UseCustomSwaggerMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                // Middleware to expose SwaggerDocument objects as JSON endpoints.
                // SwaggerDocument endpoint template is "routePrefix/{documentName}/swagger.json".
                // The default value is swagger/v1/swagger.json
                app.UseSwagger(opt =>
                {
                    opt.RouteTemplate = "Documentation/{documentName}/swagger.json";
                });
                // It interprets Swagger JSON to build a rich, customizable experience for describing the web API functionality.
                app.UseSwaggerUI(opt =>
                {
                    opt.SwaggerEndpoint("/Documentation/Demo.api/swagger.json", "Demo App");
                    opt.RoutePrefix = "Documentation";
                    opt.InjectStylesheet("/Swagger/swagger-ui.css");
                    opt.EnablePersistAuthorization();
                });

            }
            return app;
        }
    }
}
