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
builder.Services.AddSingleton<FinancialOperationServices>();
builder.Services.AddSingleton<IncomeExpensesServices>();
builder.Services.AddSingleton<ReportsServices>();
builder.Services.AddHttpClient<IFInancialOperationServices, FinancialOperationServices>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7258/");
});
builder.Services.AddHttpClient<IIncomeExpensesServices, IncomeExpensesServices>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7258/");
});
builder.Services.AddHttpClient<IReportsServices, ReportsServices>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7258");
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
