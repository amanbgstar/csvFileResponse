using EF_Multilayer.Domain.Context;
using EF_Multilayer.Repository.EmpRepo;
using EF_Multilayer.Repository.SkillRepo;
using EF_Multilayer.Repository.SystemDetailsRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<EmployeeContext>(options =>
options.
UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ISystemDetailsRepo, SystemDetailsRepo>();
builder.Services.AddScoped<ISkillRepo, SkillRepo>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
