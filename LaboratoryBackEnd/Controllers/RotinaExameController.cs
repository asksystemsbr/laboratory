﻿using LaboratoryBackEnd.Service.Interface;
using LaboratoryBackEnd.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class RotinaExameController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IRotinaExameService _service;

        public RotinaExameController(ILoggerService loggerService, IRotinaExameService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<RotinaExame>>> GetRotinaExames()
        {
            var items = await _service.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<RotinaExame>> GetRotinaExame(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutRotinaExame(int id, RotinaExame rotinaExame)
        {
            if (id != rotinaExame.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(rotinaExame);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(rotinaExame);
                await _loggerService.LogError<RotinaExame>(HttpContext.Request.Method, rotinaExame, User, ex);
                if (!RotinaExameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(rotinaExame);
                await _loggerService.LogError<RotinaExame>(HttpContext.Request.Method, rotinaExame, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<RotinaExame>> PostRotinaExame(RotinaExame rotinaExame)
        {
            try
            {
                var created = await _service.Post(rotinaExame);
                return CreatedAtAction("GetRotinaExame", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(rotinaExame);
                await _loggerService.LogError<RotinaExame>(HttpContext.Request.Method, rotinaExame, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteRotinaExame(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            try
            {
                await _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(item);
                await _loggerService.LogError<RotinaExame>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool RotinaExameExists(int id)
        {
            return _service.Exists(id);
        }
    }
}