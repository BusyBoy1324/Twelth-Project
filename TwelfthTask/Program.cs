global using TwelfthTask.Data;
global using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TwelfthTask.Models;
using TwelfthTask.Services;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<FinancialOperationDto, FinancialOperation>();
    cfg.CreateMap<IncomeExpensesDto, IncomeExpenses>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<TwelfthProjectContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TwelfthProjectContext"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IFinancialOperationServices, FinancialOperationServices>();
builder.Services.AddScoped<IIncomeExpensesTypeServices, IncomeExpensesTypeServices>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
