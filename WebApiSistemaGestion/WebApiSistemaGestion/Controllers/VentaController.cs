using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness.Services;
using SistemaGestionDTO;
using SistemaGestionEntities.models;
using System.Net;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private readonly SaleService _saleService;

        public VentaController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("{idUsuario}")]
        [ProducesResponseType(typeof(List<VentaDTO>), 200)]
        public List<VentaDTO> ObtenerVentasIdUsuario(int idUsuario)
        {
            List<VentaDTO> ventas = this._saleService.GetSaleByUserId(idUsuario);

 
                return ventas;
          

        }


        [HttpPost("{idUsuario}")]

        public IActionResult CrearVenta(int idUsuario,[FromBody] List<ProductoDTO> producto) 
        {
            if(producto.Count == 0)
            {
                return BadRequest(new { message = "The products necessary for sale were not received", status = HttpStatusCode.BadRequest });
            }
            try
            {
                this._saleService.AddSale(idUsuario, producto);
                IActionResult result = base.Created(nameof(CrearVenta), new { message = "Sale successful" });

                return result;
            }
            catch(Exception ex)
            {
                return base.Conflict(new { menssage = "Could not create sale", ex.Message, status = 400 });
            }
           


        }
    }
}
