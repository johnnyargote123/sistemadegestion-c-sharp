using SistemaGestionDTO;
using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionMapper
{
    public class SaleMapper
    {

        public Venta SaleToMapper(VentaDTO dto)
        {
            Venta venta = new Venta();
            venta.Id = dto.Id;
            venta.Comentarios = dto.Comentarios;
            venta.IdUsuario = dto.IdUsuario;
            return venta;

        }


        public VentaDTO SaleDTOToMapper(Venta venta)
        {
            VentaDTO dto = new VentaDTO();
            dto.Id = venta.Id;
            dto.Comentarios = venta.Comentarios;
            dto.IdUsuario = venta.IdUsuario;
            return dto;
        }

        public List<VentaDTO> ListSaleDTOToMapper(List<Venta> listaVentas)
        {
            List<VentaDTO> dtos = new List<VentaDTO>();

            foreach (var venta in listaVentas)
            {
                VentaDTO dto = SaleDTOToMapper(venta);
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
