using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TwelfthTask.Infrastructure;
using TwelfthTask.Models;

namespace TwelfthTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyReportController : ControllerBase
    {
        private readonly IDailyReportRepos _dailyReport;
        private readonly IUnitOfWork _unitOfWork;

        public DailyReportController(IDailyReportRepos dailyReport, IUnitOfWork unitOfWork)
        {
            _dailyReport = dailyReport;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{date}")]
        public async Task<ActionResult<DailyReport>> GetDailyRepotByDate(DateTime date)
        {
            List<FinancialOperation> financialOperations = new List<FinancialOperation>();
            int expenses = 0, income = 0;
            var finOp = await _unitOfWork.FinancialOperation.GetAllAsync();
            var samples = _dailyReport.GetInformationAboutDate(finOp, date);
            financialOperations = samples.financialOperations;
            income = samples.income;
            expenses = samples.expenses;

            var dailyReport = new DailyReport(date, income, expenses, financialOperations);
            return Ok(dailyReport);
        }
    }
}
