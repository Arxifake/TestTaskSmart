using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTaskSmart.Server.DataAccess.DBContext;
using TestTaskSmart.Server.DataAccess.Interfaces;
using TestTaskSmart.Server.DataAccess.Repositories;
using TestTaskSmart.Server.DTO;
using TestTaskSmart.Server.Services;
using TestTaskSmart.Server.Services.ServicesInterfaces;

var builder = WebApplication.CreateBuilder(args);

var conStr = builder.Configuration.GetConnectionString("DefaultConnection");
var db = builder.Services.AddDbContext<TestAppContext>(options => options.UseSqlServer(conStr));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperDTO());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton<IEmployees, Employees>();
builder.Services.AddSingleton<IApprovalRequests,ApprovalRequests>();
builder.Services.AddSingleton<ILeaveRequests, LeaveRequests>();
builder.Services.AddSingleton<IProjects, Projects>();
builder.Services.AddSingleton<IPositions, Positions>();
builder.Services.AddSingleton<ISubdivisions, Subdivisions>();
builder.Services.AddSingleton<IProjects, Projects>();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddSingleton<IApprovalRequestService, ApprovalRequestService>();
builder.Services.AddSingleton<IProjectService, ProjectService>();
builder.Services.AddSingleton<ISubdivisionService, SubdivisionService>();
builder.Services.AddSingleton<IPositionService, PositionService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
