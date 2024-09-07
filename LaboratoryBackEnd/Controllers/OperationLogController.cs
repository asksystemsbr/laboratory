using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationLogController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IOperationLogService _service;

        public OperationLogController(ILoggerService loggerService, IOperationLogService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationLog>>> GetOperationLogs()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OperationLog>> GetOperationLog(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperationLog(int id, OperationLog operationLog)
        {
            if (id != operationLog.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(operationLog);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.Exists(id))
                {
                    return NotFound();
                }
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<OperationLog>> PostOperationLog(OperationLog operationLog)
        {
            var createdOperationLog = await _service.Post(operationLog);
            return CreatedAtAction(nameof(GetOperationLog), new { id = createdOperationLog.ID }, createdOperationLog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperationLog(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            await _service.Delete(id);
            return NoContent();
        }
    }
}