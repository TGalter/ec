using App.Commands;
using App.Commands.Product;
using App.DTOs;
using App.Queries.Product;
using Dom.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("search")]
        public async Task<ActionResult<SearchResult<ProductDto>>> Search(
            [FromQuery] string query,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("O termo de pesquisa não pode ser vazio.");

            var productsQuery = new SearchProductsQuery(query, page, pageSize);
            var result = await _mediator.Send(productsQuery);

            if (result == null || result.Items.Count == 0)
                return NotFound("Nenhum produto encontrado com o termo de pesquisa fornecido.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = productId }, productId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID do caminho diferente do corpo");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdate(Guid id, [FromBody] UpdateProductPartialCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID da rota diferente do corpo.");

            await _mediator.Send(command);
            return NoContent();
        }
    }
}

