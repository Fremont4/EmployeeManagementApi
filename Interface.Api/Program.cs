using Interface.Api.App_Repositories.EmployeeRepo;
using Interface.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repository services registration
builder.Services.AddTransient<IEmployeeRepo,EmployeeRepo>();

//bab injecting the dependency

builder.Services.AddDbContext<InterfaceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InterfaceConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//use cors to communicate btwn the two angular and .net
app.UseCors(policy=>policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
