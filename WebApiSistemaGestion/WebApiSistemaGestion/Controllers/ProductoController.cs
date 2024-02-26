using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness.Services;
using SistemaGestionDTO;
using SistemaGestionEntities.models;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly ProductService _productService;

        public ProductoController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{idUsuario}")]
        [ProducesResponseType(typeof(List<ProductoDTO>), 200)]
        public List<ProductoDTO> ObtenerProductoPorIdUsuario(int idUsuario) 
        {
            List<ProductoDTO> productos  = this._productService.GetProductByUserId(idUsuario);

            return productos;
            //return base.Ok(new { message = $"we found products registered to this user",productos = productos   , status = 200 });
            
        }

        [HttpPost]

        public IActionResult CrearProducto ([FromBody] ProductoDTO producto)
        {

            if(this._productService.AddProduct(producto))
            {
                return base.Ok(new { message = $"The product was created", producto = producto, status = 200 });
            }
            else
            {
                return base.Conflict(new { menssage = "Could not create product", status = 400 });
            }
        }

        [HttpPut]

        public IActionResult ActualizarProducto(ProductoDTO productoDTO)
        {
            if (this._productService.UpdateProduct(productoDTO))
            {
                return base.Ok(new { message = "The product was updated successfully", status = 200, producto = productoDTO });
            }
            else
            {
                return base.BadRequest(new { status = 400, message = "Could not update the product" });
            }


        }

        [HttpDelete("{idProducto}")]

        public IActionResult BorrarProductoPorId(int idProducto)
        {

            if (idProducto  >= 0)
            {
                if (this._productService.DeleteProduct(idProducto))
                {
                    return base.Ok(new { message = "The product was deleted successfully", status = 200, producto = idProducto });
                }
                else
                {
                    return base.BadRequest(new { status = 400, message = "Could not delete the product" });
                }
            }
            else
            {
                return base.BadRequest(new { status = 400, message = "The id can no be negative number and less to zero" });
            }
        }


    }
}
