using SistemaGestionDTO;
using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionMapper
{
    public class ProductMapper
    {
        public Producto ProductToMapper(ProductoDTO dto)
        {
            Producto producto = new Producto();
            producto.Id = dto.Id;
            producto.Descripciones = dto.Descripciones;
            producto.PrecioVenta = dto.PrecioVenta;
            producto.Stock = dto.Stock;
            producto.Costo = dto.Costo;
            producto.IdUsuario = dto.IdUsuario;

            return producto;

        }


        public ProductoDTO ProductDTOToMapper(Producto producto)
        {
            ProductoDTO dto = new ProductoDTO();
            dto.Id = producto.Id;
            dto.Descripciones = producto.Descripciones;
            dto.PrecioVenta = producto.PrecioVenta;
            dto.Stock = producto.Stock;
            dto.Costo = producto.Costo;
            dto.IdUsuario = producto.IdUsuario;

            return dto;
        }

        public List<ProductoDTO> ListProductDTOToMapper(List<Producto> listaproductos)
        {
            List<ProductoDTO> dtos = new List<ProductoDTO>();

            foreach (var producto in listaproductos)
            {
                ProductoDTO dto = ProductDTOToMapper(producto);
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
