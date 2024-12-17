using DotNetOpenAPI.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICRUDActions,CRUDActions>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Swagger Documentation Section
var info = new OpenApiInfo()
{
    Title = "DotNet CRUD WebAPI With Open API Documentation",
    Version = "v1",
    Description = "This is a sample API created using .NET Core to test documentation process using OpenAPI",
    Contact = new OpenApiContact()
    {
        Name = "Kaushik Natua",
        Email = "kaushik.natua@hyland.com",
    }
};

// Set the comments path for the Swagger JSON and UI.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", info);

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(u =>
    {
        u.RouteTemplate = "swagger/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "swagger";
        c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "DotNet CRUD API or Version");
    });
}

app.UseAuthorization();

app.MapControllers();



app.Run();
