using AutoMapper;
using AbarrotesControl.Core.DTOs;
using AbarrotesControl.Core.Entities;

namespace AbarrotesControl.Infrastructure.Mappings
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<EntradaMercaderia, EntradaMercaderiaDto>().ReverseMap();
            CreateMap<DetalleEntrada, DetalleEntradaDto>().ReverseMap();
        }
    }
}