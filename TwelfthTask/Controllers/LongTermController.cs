using Microsoft.AspNetCore.Mvc;
using TwelfthTask.Models;
using TwelfthTask.Services;

namespace TwelfthTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LongTermController : ControllerBase
    {
        private readonly IGetReports _reports;

        public LongTermController(IGetReports reports)
        {
            _reports = reports;
        }

        [HttpGet("{startDate}, {endDate}")]
        public async Task<ActionResult<LongTermReport>> GetLongTermRepotByDate(DateTime startDate, DateTime endDate)
        {
            var dailyReport = await _reports.GetLongTermReportAsync(startDate, endDate);
            return Ok(dailyReport);
        }
    }
}
