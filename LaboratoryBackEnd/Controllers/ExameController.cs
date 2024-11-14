using LaboratoryBackEnd.Data.DTO;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IExameService _service;

        public ExameController(ILoggerService loggerService, IExameService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exame>>> GetExames()
        {
            var items = await _service.GetItems();
            //if (items == null || !items.Any())
            //{
            //    return NotFound();
            //}
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exame>> GetExame(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet("getitemsByCodigo/{codigoExame}")]
        public async Task<ActionResult<Exame>> GetItemsByCodigo(string codigoExame)
        {
            var item = await _service.GetItemsByCodigo(codigoExame);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet("getExameByRecepcao/{recepcaoId}")]
        public async Task<ActionResult<IEnumerable<Exame>>> GetExameByRecepcao(int recepcaoId)
        {
            var item = await _service.GetExameByRecepcao(recepcaoId);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        

        [HttpGet("getPrecoByPlanoExame/{planoId}/{codigoExame}")]
        public async Task<ActionResult<ExameDTO>> GetPrecoByPlanoExame(string planoId, string codigoExame)
        {
            var item = await _service.GetPrecoByPlanoExame(codigoExame,planoId,false);
            //if (item == null)
            //{
            //    return NotFound();
            //}
            return Ok(item);
        }

        [HttpGet("getPrecoByPlanoExameId/{planoId}/{codigoExame}")]
        public async Task<ActionResult<ExameDTO>> getPrecoByPlanoExameId(string planoId, string codigoExame)
        {
            var item = await _service.GetPrecoByPlanoExame(codigoExame, planoId,true);
            //if (item == null)
            //{
            //    return NotFound();
            //}
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExame(int id, Exame exame)
        {
            if (id != exame.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(exame);
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
        public async Task<ActionResult<Exame>> PostExame(Exame exame)
        {
            var createdExame = await _service.Post(exame);
            return CreatedAtAction(nameof(GetExame), new { id = createdExame.ID }, createdExame);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExame(int id)
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