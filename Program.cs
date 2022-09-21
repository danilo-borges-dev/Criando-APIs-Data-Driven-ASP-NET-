using Microsoft.EntityFrameworkCore;
using Shop.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


#region Conexão Conexão com o Banco de Dados
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseInMemoryDatabase("Database");    
});
builder.Services.AddScoped<DataContext, DataContext>(); // <- Fecha a Conexão com o Banco de Dados
// Acima - O bloco de Conexão com o Banco de Dados
#endregion

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

app.UseAuthorization();

app.MapControllers();

app.Run();
