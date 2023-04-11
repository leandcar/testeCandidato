using DesafioSbCreditoAPI.Domain.Services;
using DesafioSbCreditoAPI.Domain.Services.Interfaces;
using DesafioSbCreditoAPI.Infra.Data;
using DesafioSbCreditoAPI.Repositories;
using DesafioSbCreditoAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add MongoDbConnection
builder.Services.Configure<MongoDbConfig>(
    builder.Configuration.GetSection("MongoDbConnection"));

builder.Services.AddScoped<IOperacaoService, OperacaoService>();
builder.Services.AddScoped<IOperacaoRepository, OperacaoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
