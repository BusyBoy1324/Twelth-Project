using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TwelfthTask.Models;
using TwelfthTask.Services;

namespace TwelfthTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeExpensesController : ControllerBase
    {
        private readonly IIncomeExpensesTypeServices _incomeExpensesServices;

        public IncomeExpensesController(IIncomeExpensesTypeServices incomeExpensesServices)
        {
            _incomeExpensesServices = incomeExpensesServices;
        }

        [HttpGet]
        [Route( "AllIncomeExpenses")]
        public async Task<ActionResult<List<IncomeExpenses>>> GetAllIncomeExpensesAsync()
        {
            return Ok(await _incomeExpensesServices.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeExpenses>> GetIncomeExpensesByIdAsync(int id)
        {
            var incomeExpenses = await _incomeExpensesServices.FindAsync(id);
            return Ok(incomeExpenses);
        }

        [HttpPost]
        [Route("CreateIncomeExpenses")]
        public async Task<ActionResult<List<IncomeExpenses>>> AddIncomeExpensesAsync([FromBody] IncomeExpensesDto incomeExpensesCreate)
        {
            var incomeExpenses = await _incomeExpensesServices.InsertAsync(incomeExpensesCreate);
            return Ok(incomeExpenses);
        }

        [HttpPut]
        [Route("UpdateIncomeExpenses")]
        public async Task<ActionResult<IncomeExpenses>> UpdateIncomeExpensesAsync(
            [FromBody] IncomeExpenses request)
        {
            await _incomeExpensesServices.UpdateAsync(request);
            return Ok(request);
        }

        [HttpDelete]
        [Route("DeleteIncomeExpenses")]
        public async Task<ActionResult<List<IncomeExpenses>>> DeleteIncomeExpensesAsync([FromQuery] int id)
        {
            await _incomeExpensesServices.DeleteAsync(id);
            return Ok(await _incomeExpensesServices.GetAllAsync());
        }
    }
}
