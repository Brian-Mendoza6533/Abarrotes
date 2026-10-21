using Microsoft.AspNetCore.Mvc;
using AbarrotesControl.Core.Entities;
using AbarrotesControl.Core.Interfaces;
using AbarrotesControl.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbarrotesControl.Api.Controllers
{
    [Route("api/entradas")]
    [ApiController]
    public class EntradasController : ControllerBase
    {
        private readonly IEntradaRepository _entradaRepository;
        private readonly IProductoRepository _productoRepository;

        public EntradasController(IEntradaRepository entradaRepository, IProductoRepository productoRepository)
        {
            _entradaRepository = entradaRepository;
            _productoRepository = productoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarEntrada([FromBody] EntradaMercaderiaDto dto)
        {
            if (dto.Detalle == null || dto.Detalle.Count == 0)
                return BadRequest(new { message = "La entrada debe tener al menos un producto en su detalle (RN-08)." });

            var stockAumentos = new Dictionary<int, int>();
            var detallesEntrada = new List<DetalleEntrada>();

            foreach (var item in dto.Detalle)
            {
                if (item.Cantidad <= 0)
                    return BadRequest(new { message = "La cantidad recibida debe ser mayor a 0 (RN-09)." });
                if (item.CostoUnitario < 0)
                    return BadRequest(new { message = "El costo unitario no puede ser negativo (RN-10)." });

                var producto = await _productoRepository.GetProductoByIdAsync(item.ProductoId);
                if (producto == null)
                    return NotFound(new { message = $"El producto ID {item.ProductoId} no existe." });

                if (producto.FechaVencimiento.HasValue && producto.FechaVencimiento.Value < DateOnly.FromDateTime(DateTime.Today))
                    return BadRequest(new { message = $"No se puede registrar la entrada del producto '{producto.Nombre}' porque ya está vencido (RN-11)." });

                stockAumentos.Add(item.ProductoId, item.Cantidad);
                detallesEntrada.Add(new DetalleEntrada
                {
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad,
                    CostoUnitario = item.CostoUnitario
                });
            }

            var entrada = new EntradaMercaderia
            {
                ProveedorId = dto.ProveedorId,
                UsuarioId = dto.UsuarioId,
                FechaCompra = DateOnly.Parse(dto.FechaCompra),
                RegistradoEn = DateTime.Now,
                Observacion = dto.Observacion,
                DetalleEntradas = detallesEntrada
            };

            await _entradaRepository.RegistrarEntradaAsync(entrada, stockAumentos);
            return StatusCode(201, new { message = "Entrada registrada correctamente y stock actualizado." });
        }
    }
}