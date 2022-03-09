using Microsoft.EntityFrameworkCore;
using TIP.Contexts;
using TIP.IRepositories;
using TIP.IServices;
using TIP.MiddleWares;
using TIP.Repositories;
using TIP.Services;

var builder = WebApplication.CreateBuilder(args);

string _connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TIPContext>(options =>
    options.UseMySql(_connectionString,
    ServerVersion.AutoDetect(_connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEnterpriseService, EnterpriseService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentEmployeeService, DepartmentEmployeeService>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentEmployeeRepository, DepartmentEmployeeRepository>();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GeneralResponseMiddleWare>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
