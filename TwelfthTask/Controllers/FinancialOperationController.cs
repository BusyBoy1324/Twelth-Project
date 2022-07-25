using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwelfthTask.Models;
using TwelfthTask.Services;

namespace TwelfthTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialOperationController : ControllerBase
    {
        private readonly IFinancialOperationServices _finServices;

        public FinancialOperationController(IFinancialOperationServices finServices)
        {
            _finServices = finServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<FinancialOperation>>> GetAllAsync()
        {
            return Ok(await _finServices.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialOperation>> GetByIdAsync(int id)
        {
            var financialOperation = await _finServices.FindAsync(id);
            return Ok(financialOperation);
        }

        [HttpPost]
        public async Task<ActionResult<FinancialOperation>> AddFinancialOperationAsync([FromBody] FinancialOperationDto financialOperationCreate)
        {
            var financialOperation = await _finServices.InsertAsync(financialOperationCreate);
            return Ok(financialOperation);
        }

        [HttpPut]
        public async Task<ActionResult<FinancialOperation>> UpdateFinancialOperation(
            [FromBody] FinancialOperation request)
        {
            await _finServices.UpdateAsync(request);
            return Ok(request);
        }

        [HttpDelete]
        public async Task<ActionResult<List<FinancialOperation>>> DeleteFinancialOperationAsync([FromQuery] int id)
        {
            await _finServices.Delete(id);
            return Ok(await _finServices.GetAllAsync());
        }
    }
}
