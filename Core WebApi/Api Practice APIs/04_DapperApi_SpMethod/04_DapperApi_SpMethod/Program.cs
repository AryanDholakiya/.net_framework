using _04_DapperApi_SpMethod.Models;
using _04_DapperApi_SpMethod.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//NOTE
builder.Services.AddScoped<IPersonRepo, PersonRepo>();

builder.Services.AddDbContext<DapperExampleQueryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DapperApiUsinSp"));
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
