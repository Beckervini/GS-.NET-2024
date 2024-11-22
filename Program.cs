using GreenFundGS.Data;
using GreenFundGS.Repositories;
using GreenFundGS.Services;
using GreenFundGS.Interfaces;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using GreenFundGS.Configurations;
using GreenFundGS.Factories;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Configuração dos serviços para a aplicação.
/// </summary>

// Configuração dos controladores da API.
builder.Services.AddControllers();

/// <summary>
/// Configuração do Swagger/OpenAPI para documentação da API.
/// </summary>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// <summary>
/// Registrar o contexto de banco de dados Oracle.
/// </summary>
builder.Services.AddDbContext<GreenFundContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

/// <summary>
/// Configuração de injeção de dependências.
/// </summary>
DependencyInjectionConfig.RegisterServices(builder.Services);

/// <summary>
/// Registro do RewardFactory no contêiner de injeção de dependência.
/// </summary>
builder.Services.AddScoped<IRewardFactory, RewardFactory>();

/// <summary>
/// Configuração do AutoMapper.
/// </summary>
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

/// <summary>
/// Configuração de política de CORS.
/// </summary>
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

/// <summary>
/// Configuração do pipeline de requisições HTTP.
/// </summary>
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "GreenFund API v1");
        options.RoutePrefix = "swagger"; // Altera a rota do Swagger para "/swagger"
    });
}


app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
