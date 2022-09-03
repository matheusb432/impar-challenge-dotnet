using ImparApp.Api.Configurations;
using ImparApp.Application.Configurations;
using ImparApp.Infra.Configurations;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers().AddOData(
    opt => opt.Count().Filter().OrderBy().SetMaxTop(50));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencyInjectionConfig();
builder.Services.AddDatabaseConfiguration(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionHandlerMiddleware();

app.MapControllers();

app.Run();
