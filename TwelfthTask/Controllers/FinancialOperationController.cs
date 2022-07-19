using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwelfthTask.Infrastructure;
using TwelfthTask.Models;
using TwelfthTask.Services;

namespace TwelfthTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialOperationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinancialOperationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<FinancialOperation>>> Get()
        {
            return Ok(await _unitOfWork.FinancialOperation.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialOperation>> GetById(int id)
        {
            var financialOperation = await _unitOfWork.FinancialOperation.FindAsync(id);
            if (financialOperation == null)
            {
                return BadRequest("Financial operation not found.");
            }
            return Ok(financialOperation);
        }

        [HttpPost]
        public async Task<ActionResult<List<FinancialOperation>>> AddFinancialOperation(FinancialOperationCreate financialOperationCreate)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FinancialOperationCreate, FinancialOperation>());
            var mapper = config.CreateMapper();
            FinancialOperation financialOperation = mapper.Map<FinancialOperation>(financialOperationCreate);
            _unitOfWork.FinancialOperation.Insert(financialOperation);
            await _unitOfWork.Save();

            return Ok(await _unitOfWork.FinancialOperation.GetAllAsync());
        }

        [HttpPut]
        public async Task<ActionResult<FinancialOperation>> UpdateFinancialOperation(
             FinancialOperation request)
        {
            var dbFinancialOperation = await _unitOfWork.FinancialOperation.FindAsync(request.Id);
            if (dbFinancialOperation == null)
            {
                return BadRequest("Financial operation not found");
            }

            _unitOfWork.FinancialOperation.Update(request);
            await _unitOfWork.Save();

            return Ok(await _unitOfWork.FinancialOperation.GetAllAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<FinancialOperation>>> DeleteFinancialOperation(int id)
        {
            var dbFinancialOperation = await _unitOfWork.FinancialOperation.FindAsync(id);
            if (dbFinancialOperation == null)
            {
                return BadRequest("Financial operation not found");
            }
            
            _unitOfWork.FinancialOperation.Delete(dbFinancialOperation);
            await _unitOfWork.Save();

            return Ok(await _unitOfWork.FinancialOperation.GetAllAsync());
        }
    }
}
