using CFM.Application.Mappers;
using CFM.Application.Services;
using CFM.Application.Validators;
using CFM.Domain.Interfaces;
using CFM.Domain.Interfaces.Repositories;
using CFM.Domain.Interfaces.Services;
using CFM.Domain.Services;
using CFM.Infrastructure.Data;
using CFM.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonDateConverter()));

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ILancamentoService, LancamentoService>();
builder.Services.AddScoped<IConsolidadoService, ConsolidadoService>();

builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();

builder.Services.AddAutoMapper(typeof(LancamentoMapper));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Lançamentos",
        Version = "v1",
        Description = "API para gerenciar lançamentos financeiros",
        Contact = new OpenApiContact
        {
            Name = "Equipe de Desenvolvimento",
            Email = "flaviorsm@gmail.com",
            Url = new Uri("https://github.com/flaviorsm")
        }
    });

    // Adicionar comentários XML se habilitado
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
