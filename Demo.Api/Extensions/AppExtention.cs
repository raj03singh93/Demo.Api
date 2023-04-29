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
            });
            return services;
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
                });
            }
            return app;
        }
    }
}
