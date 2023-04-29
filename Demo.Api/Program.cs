using Demo.Api.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomeSwagger();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();
app.UseCustomSwaggerMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
