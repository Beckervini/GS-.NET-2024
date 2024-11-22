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
/// Configura��o dos servi�os para a aplica��o.
/// </summary>

// Configura��o dos controladores da API.
builder.Services.AddControllers();

/// <summary>
/// Configura��o do Swagger/OpenAPI para documenta��o da API.
/// </summary>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// <summary>
/// Registrar o contexto de banco de dados Oracle.
/// </summary>
builder.Services.AddDbContext<GreenFundContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

/// <summary>
/// Configura��o de inje��o de depend�ncias.
/// </summary>
DependencyInjectionConfig.RegisterServices(builder.Services);

/// <summary>
/// Registro do RewardFactory no cont�iner de inje��o de depend�ncia.
/// </summary>
builder.Services.AddScoped<IRewardFactory, RewardFactory>();

/// <summary>
/// Configura��o do AutoMapper.
/// </summary>
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

/// <summary>
/// Configura��o de pol�tica de CORS.
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
/// Configura��o do pipeline de requisi��es HTTP.
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
