using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using AbarrotesControl.Core.Entities;
using AbarrotesControl.Core.Interfaces;
using AbarrotesControl.Core.DTOs;
using System.Threading.Tasks;

namespace AbarrotesControl.Api.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductoDto> _validator;

        public ProductosController(
            IProductoRepository productoRepository,
            IMapper mapper,
            IValidator<ProductoDto> validator)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _productoRepository.GetProductosAsync();
            var productosDto = _mapper.Map<IEnumerable<ProductoDto>>(productos);
            return Ok(productosDto);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarProducto([FromBody] ProductoDto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var producto = _mapper.Map<Producto>(dto);
            await _productoRepository.InsertProductoAsync(producto);

            var resultDto = _mapper.Map<ProductoDto>(producto);
            return StatusCode(201, new { message = "Producto registrado correctamente", data = resultDto });
        }
    }
}