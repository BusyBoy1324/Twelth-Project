using Microsoft.AspNetCore.Mvc;
using TwelfthTask.Models;
using TwelfthTask.Services;

namespace TwelfthTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsContoller : ControllerBase
    {
        private readonly IReportService _reports;

        public ReportsContoller(IReportService reports)
        {
            _reports = reports;
        }

        [HttpGet("{date}")]
        public async Task<ActionResult<DailyReport>> GetDailyRepotByDate([FromRoute] DateTime date)
        {
            var dailyReport = await _reports.GetDailyReportAsync(date);
            return Ok(dailyReport);
        }

        [HttpGet("{startDate}, {endDate}")]
        public async Task<ActionResult<LongTermReport>> GetLongTermRepotByDate
            ([FromRoute] DateTime startDate, [FromRoute] DateTime endDate)
        {
            var dailyReport = await _reports.GetLongTermReportAsync(startDate, endDate);
            return Ok(dailyReport);
        }
    }
}
