using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WebAppAzureFunction",
        Version = "v1",
        Description = "Web App Azure Function ASP.NET Core Web API with Swagger",
        Contact = new OpenApiContact
        {
            Name = "Paul Faye",
            Email = "fayepaul234@gmail.com"
        }
    });
});

var app = builder.Build();

// Enable Swagger in Development (or all environments if you prefer)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAppAzureFunction v1");
        c.RoutePrefix = string.Empty; // Swagger at root URL
    });
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
