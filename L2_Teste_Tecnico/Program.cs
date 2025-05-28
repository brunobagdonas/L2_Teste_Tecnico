using L2_Teste_Tecnico.Data.Interfaces;
using L2_Teste_Tecnico.Data.Repositories;
using L2_Teste_Tecnico.Data.Util;
using L2_Teste_Tecnico.Services;
using L2_Teste_Tecnico.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services
builder.Services.AddScoped<IPackingService, PackingService>();
#endregion


#region Repositories
builder.Services.AddScoped<IPackingRepository, PackingRepository>();
builder.Services.AddScoped<IBoxRepository, BoxRepository>();
#endregion

#region Util
builder.Services.AddScoped<SqlConnectionFactory>();
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
