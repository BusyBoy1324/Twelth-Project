global using TwelfthTask.Data;
global using Microsoft.EntityFrameworkCore;
using TwelfthTask.Infrastructure;
using TwelfthTask.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<TwelfthProjectContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TwelfthProjectContext"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDailyReportRepos, DailyReportRepos>();
builder.Services.AddScoped<ILongTermReportRepos, LongTermReportRepos>();
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
