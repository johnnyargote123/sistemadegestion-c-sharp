using Microsoft.AspNetCore.Mvc;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NombreController : Controller
    {
        [HttpGet]
        public string ObtenerNombreUsuario()
        {
            return "Johnny Argote";
             //return base.Ok(new { status = 200, nombre = "Johnny Argote" });
        }
    }
}
