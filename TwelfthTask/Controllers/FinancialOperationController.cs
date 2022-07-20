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
        public async Task<ActionResult<List<FinancialOperation>>> Get()
        {
            return Ok(await _finServices.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialOperation>> GetById(int id)
        {
            var financialOperation = await _finServices.FindAsync(id);
            return Ok(financialOperation);
        }

        [HttpPost]
        public async Task<ActionResult<List<FinancialOperation>>> AddFinancialOperation(FinancialOperationCreate financialOperationCreate)
        {
            var financialOperation = _finServices.GetMappedModel(financialOperationCreate);
            _finServices.Insert(financialOperation);
            _finServices.Save();

            return Ok(await _finServices.GetAllAsync());
        }

        [HttpPut]
        public async Task<ActionResult<FinancialOperation>> UpdateFinancialOperation(
             FinancialOperation request)
        {
            var dbFinancialOperation = await _finServices.FindAsync(request.Id);
            _finServices.Update(request);
            _finServices.Save();

            return Ok(await _finServices.GetAllAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<FinancialOperation>>> DeleteFinancialOperation(int id)
        {
            var dbFinancialOperation = await _finServices.FindAsync(id);
            _finServices.Delete(dbFinancialOperation);
            _finServices.Save();

            return Ok(await _finServices.GetAllAsync());
        }
    }
}
