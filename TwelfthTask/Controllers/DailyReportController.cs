using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TwelfthTask.Models;
using TwelfthTask.Services;

namespace TwelfthTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyReportController : ControllerBase
    {
        private readonly IGetReports _reports;

        public DailyReportController(IGetReports reports)
        {
            _reports = reports;
        }

        [HttpGet("{date}")]
        public async Task<ActionResult<DailyReport>> GetDailyRepotByDate(DateTime date)
        {
            var dailyReport = await _reports.GetDailyReportAsync(date);
            return Ok(dailyReport);
        }
    }
}
