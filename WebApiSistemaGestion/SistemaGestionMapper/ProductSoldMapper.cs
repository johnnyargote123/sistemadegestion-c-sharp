using SistemaGestionDTO;
using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionMapper
{
    public class ProductSoldMapper
    {

        public ProductoVendido ProductSoldToMapper(ProductoVendidoDTO dto)
        {
            ProductoVendido productoVendido = new ProductoVendido();
            productoVendido.Id = dto.Id;
            productoVendido.IdProducto = dto.IdProducto;
            productoVendido.IdVenta = dto.IdVenta;
            productoVendido.Stock = dto.Stock;
 
            return productoVendido;

        }


        public ProductoVendidoDTO ProductSoldDTOToMapper(ProductoVendido productoVendido)
        {
            ProductoVendidoDTO dto = new ProductoVendidoDTO();
            dto.Id = productoVendido.Id;
            dto.IdProducto = productoVendido.IdProducto;
            dto.IdVenta = productoVendido.IdVenta;
            dto.Stock = productoVendido.Stock;
            return dto;
        }

        public List<ProductoVendidoDTO> ListProductSoldDTOToMapper(List<ProductoVendido> listaProductoVendido)
        {
            List<ProductoVendidoDTO> dtos = new List<ProductoVendidoDTO>();

            foreach (var productoVendido in listaProductoVendido)
            {
                ProductoVendidoDTO dto = ProductSoldDTOToMapper(productoVendido);
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
