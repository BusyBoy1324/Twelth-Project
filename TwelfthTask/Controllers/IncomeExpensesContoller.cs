using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TwelfthTask.Models;
using TwelfthTask.Services;

namespace TwelfthTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeExpensesContoller : ControllerBase
    {
        private readonly IIncomeExpensesTypeServices _incomeExpensesServices;

        public IncomeExpensesContoller(IIncomeExpensesTypeServices incomeExpensesServices)
        {
            _incomeExpensesServices = incomeExpensesServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<IncomeExpenses>>> GetIncomeExpenses()
        {
            return Ok(await _incomeExpensesServices.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeExpenses>> GetIncomeExpensesById(int id)
        {
            var incomeExpenses = await _incomeExpensesServices.FindAsync(id);
            return Ok(incomeExpenses);
        }

        [HttpPost]
        public async Task<ActionResult<List<IncomeExpenses>>> AddIncomeExpenses(IncomeExpensesCreate incomeExpensesCreate)
        {
            var incomeExpenses = _incomeExpensesServices.GetMappedModel(incomeExpensesCreate);
            _incomeExpensesServices.Insert(incomeExpenses);
            _incomeExpensesServices.Save();

            return Ok(await _incomeExpensesServices.GetAllAsync());
        }

        [HttpPut]
        public async Task<ActionResult<IncomeExpenses>> UpdateIncomeExpenses(
            IncomeExpenses request)
        {
            var incomeExpenses = await _incomeExpensesServices.FindAsync(request.Id);
            _incomeExpensesServices.Update(request);
            _incomeExpensesServices.Save();

            return Ok(await _incomeExpensesServices.GetAllAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<IncomeExpenses>>> DeleteIncomeExpenses(int id)
        {
            var incomeExpenses = await _incomeExpensesServices.FindAsync(id);
            _incomeExpensesServices.Delete(incomeExpenses);
            _incomeExpensesServices.Save();

            return Ok(await _incomeExpensesServices.GetAllAsync());
        }
    }
}
