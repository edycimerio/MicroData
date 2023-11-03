using FluentValidation.Results;
using Micro.Data.API.Validadores;
using Micro.Data.Domain.Dtos;
using Micro.Data.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Micro.Data.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;
        public PedidoController(IPedidoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.ListPedidos();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.Consultar(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PedidoDto pedido)
        {
            PostPedidoValidator validator = new PostPedidoValidator();

            ValidationResult results = validator.Validate(pedido);

            if (!results.IsValid)
            {
                return BadRequest(results.Errors);
            }

            await _service.Create(pedido);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(PedidoDto pedido)
        {
            await _service.Edit(pedido);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
                return BadRequest("Objeto dto está vazio!");

            await _service.Delete(id);

            return Ok();
        }
    }
}
