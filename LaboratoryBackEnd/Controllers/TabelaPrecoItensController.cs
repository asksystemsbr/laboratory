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
    public class TabelaPrecoItensController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly ITabelaPrecoItensService _service;

        public TabelaPrecoItensController(ILoggerService loggerService, ITabelaPrecoItensService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<TabelaPrecoItens>>> GetItems()
        {
            var items = await _service.GetItems();

            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<TabelaPrecoItens>> GetItem(int id)
        {
            var item = await _service.GetItem(id);
            return item;
        }

        [HttpGet("getByPriceTable/{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<List<TabelaPrecoItens>>> GetItemByPriceTable(int id)
        {
            var item = await _service.GetItemsByTable(id);
            return item;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutItem(int id, TabelaPrecoItens item)
        {
            if (id != item.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(item);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(item);
                await _loggerService.LogError<TabelaPrecoItens>(HttpContext.Request.Method, item, User, ex);
                if (!ItemExists(id))
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
                await _service.RemoveContex(item);
                await _loggerService.LogError<TabelaPrecoItens>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<TabelaPrecoItens>> PostItem(List<TabelaPrecoItens> items)
        {
            TabelaPrecoItens created = new TabelaPrecoItens();

            foreach (var item in items)
            {
                try
                {
                    if (item.TabelaPrecoId != null)
                    {
                        var itemDelete = await _service.GetItem(item.ID);
                        if (itemDelete != null)
                        {
                            await _service.Delete(itemDelete.ID);
                        }
                    }
                    item.ID = 0;
                    created = await _service.Post(item);
                }
                catch (Exception ex)
                {
                    await _service.RemoveContex(item);
                    await _loggerService.LogError<TabelaPrecoItens>(HttpContext.Request.Method, item, User, ex);
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            return CreatedAtAction("GetTabelaPrecoItens", new { id = created.ID }, created);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteItem(int id)
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
                await _loggerService.LogError<TabelaPrecoItens>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool ItemExists(int id)
        {
            return _service.Exists(id);
        }
    }
}