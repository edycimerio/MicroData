using FluentValidation.Results;
using Micro.Data.API.Validadores;
using Micro.Data.Domain.Dtos;
using Micro.Data.Domain.Entities;
using Micro.Data.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Data.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.ListProdutos();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.Consultar(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoDto produto)
        {
            PostProdutoValidator validator = new PostProdutoValidator();

            ValidationResult results = validator.Validate(produto);

            if (!results.IsValid)
            {
                return BadRequest(results.Errors);                
            }

            await _service.Create(produto);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProdutoDto produto)
        {
            PutProdutoValidator validator = new PutProdutoValidator();

            ValidationResult results = validator.Validate(produto);

            if (!results.IsValid)
            {
                return BadRequest(results.Errors);
            }

            await _service.Edit(produto);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ProdutoDto produto)
        {
            PutProdutoValidator validator = new PutProdutoValidator();

            ValidationResult results = validator.Validate(produto);

            if (!results.IsValid)
            {
                return BadRequest(results.Errors);
            }

            var item = await _service.ConsultarPorItemPedido(produto.Id);
            if (item.Id > 0)
            {
                return BadRequest("Esse produto está associado a um pedido, não é possível a exclusão!");
            }

            await _service.Delete(produto.Id);

            return Ok();
        }
    }
}
