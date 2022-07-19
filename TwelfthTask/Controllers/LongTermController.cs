using Microsoft.AspNetCore.Mvc;
using TwelfthTask.Infrastructure;
using TwelfthTask.Models;
using TwelfthTask.Services;

namespace TwelfthTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LongTermController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILongTermReportRepos _longTermReport;
        public LongTermController(ILongTermReportRepos longTermReport, IUnitOfWork untiOfWork)
        {
            _longTermReport = longTermReport;
            _unitOfWork = untiOfWork;
        }

        [HttpGet("{startDate}, {endDate}")]
        public async Task<ActionResult<LongTermReport>> GetLongTermRepotByDate(DateTime startDate, DateTime endDate)
        {
            List<FinancialOperation> financialOperations = new List<FinancialOperation>();
            int expenses = 0, income = 0;
            var finOp = await _unitOfWork.FinancialOperation.GetAllAsync();
            var samples = _longTermReport.GetInformationAboutDatePeriod(finOp, startDate, endDate);
            financialOperations = samples.financialOperations;
            income = samples.income;
            expenses = samples.expenses;

            var dailyReport = new LongTermReport(startDate, endDate, income, expenses, financialOperations);
            return Ok(dailyReport);
        }
    }
}
