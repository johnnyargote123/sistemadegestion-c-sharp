using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness.Services;
using SistemaGestionDTO;
using SistemaGestionEntities.models;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : Controller
    {
        private readonly ProductsSoldService _productsSoldService;

        public ProductoVendidoController(ProductsSoldService productsSoldService)
        {
            _productsSoldService = productsSoldService;
        }


        [HttpGet("{idUsuario}")]
        [ProducesResponseType(typeof(IEnumerable<ProductoVendidoDTO>), 200)]
        public IActionResult ObtenerProductosVendidosAUsuarios(int idUsuario)
        {
            

            List<ProductoVendidoDTO> productosVendidos = this._productsSoldService.GetProductSoldByUserId(idUsuario); ;



            if (productosVendidos.Count > 0)
            {
                return base.Ok(new { message = $"we found products sold registered to this user", productosVendidos = productosVendidos, status = 200 });
            }
            else
            {
                return base.Ok(new { message = $"Not found products sold registered to this user", productosVendidos = productosVendidos, status = 200 });
            }
        }

    }
}
