global using BlazorUI.Services.IncomeExpensesService;
using BlazorUI.Services;
using BlazorUI.Services.FinancialOperationsServices;
using BlazorUI.Services.ReportsServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IFInancialOperationServices, FinancialOperationServices>();
builder.Services.AddSingleton<IIncomeExpensesServices, IncomeExpensesServices>();
builder.Services.AddSingleton<IReportsServices, ReportsServices>();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddHttpClient("client", c =>
{
    c.BaseAddress = new Uri(configuration.GetValue<string>("RestIg"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
