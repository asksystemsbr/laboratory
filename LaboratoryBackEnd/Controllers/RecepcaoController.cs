using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcaoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IRecepcaoService _service;

        public RecepcaoController(ILoggerService loggerService, IRecepcaoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recepcao>>> GetRecepcoes()
        {
            var items = await _service.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recepcao>> GetRecepcao(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecepcao(int id, Recepcao recepcao)
        {
            if (id != recepcao.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(recepcao);
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
        public async Task<ActionResult<Recepcao>> PostRecepcao(Recepcao recepcao)
        {
            var createdRecepcao = await _service.Post(recepcao);
            return CreatedAtAction(nameof(GetRecepcao), new { id = createdRecepcao.ID }, createdRecepcao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecepcao(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            await _service.Delete(id, item.EnderecoId);
            return NoContent();
        }
    }
}