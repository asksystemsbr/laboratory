using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IAuditLogService _service;

        public AuditLogController(ILoggerService loggerService, IAuditLogService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditLog>>> GetAuditLogs()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuditLog>> GetAuditLog(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditLog(int id, AuditLog auditLog)
        {
            if (id != auditLog.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(auditLog);
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
        public async Task<ActionResult<AuditLog>> PostAuditLog(AuditLog auditLog)
        {
            var createdAuditLog = await _service.Post(auditLog);
            return CreatedAtAction(nameof(GetAuditLog), new { id = createdAuditLog.ID }, createdAuditLog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuditLog(int id)
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