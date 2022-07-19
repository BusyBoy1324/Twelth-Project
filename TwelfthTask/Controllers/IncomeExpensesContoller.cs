using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TwelfthTask.Infrastructure;
using TwelfthTask.Models;

namespace TwelfthTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeExpensesContoller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public IncomeExpensesContoller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<IncomeExpenses>>> GetIncomeExpenses()
        {
            return Ok(await _unitOfWork.IncomeExpenses.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeExpenses>> GetIncomeExpensesById(int id)
        {
            var incomeExpenses = await _unitOfWork.IncomeExpenses.FindAsync(id);
            if (incomeExpenses == null)
            {
                return BadRequest("Income or expense not found.");
            }
            return Ok(incomeExpenses);
        }

        [HttpPost]
        public async Task<ActionResult<List<IncomeExpenses>>> AddIncomeExpenses(IncomeExpensesCreate incomeExpensesCreate)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncomeExpensesCreate, IncomeExpenses>());
            var mapper = config.CreateMapper();
            IncomeExpenses incomeExpenses = mapper.Map<IncomeExpenses>(incomeExpensesCreate);
            _unitOfWork.IncomeExpenses.Insert(incomeExpenses);
            await _unitOfWork.Save();

            return Ok(await _unitOfWork.IncomeExpenses.GetAllAsync());
        }

        [HttpPut]
        public async Task<ActionResult<IncomeExpenses>> UpdateIncomeExpenses(
            IncomeExpenses request)
        {
            var incomeExpenses = await _unitOfWork.IncomeExpenses.FindAsync(request.Id);
            if (incomeExpenses == null)
            {
                return BadRequest("Income or expense not found");
            }

            _unitOfWork.IncomeExpenses.Update(request);
            await _unitOfWork.Save();

            return Ok(await _unitOfWork.IncomeExpenses.GetAllAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<IncomeExpenses>>> DeleteIncomeExpenses(int id)
        {
            var incomeExpenses = await _unitOfWork.IncomeExpenses.FindAsync(id);
            if (incomeExpenses == null)
            {
                return BadRequest("Income or expense not found");
            }

            _unitOfWork.IncomeExpenses.Delete(incomeExpenses);
            await _unitOfWork.Save();

            return Ok(await _unitOfWork.IncomeExpenses.GetAllAsync());
        }
    }
}
