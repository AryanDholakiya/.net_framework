using _03_CRUDAPI_using_Dapper.Models;
using _03_CRUDAPI_using_Dapper.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Dapper Services Registration ---
// Reason: Register the repository interface and its concrete implementation.
// This allows the Controller to request IPersonRepository and receive PersonRepository.
// AddScoped: A new instance is created once per client request (suitable for DB repositories).
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddDbContext<DapperExampleQueryContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dapperConnString"));
}); 

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
