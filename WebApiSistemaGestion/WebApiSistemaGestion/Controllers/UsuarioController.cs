using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness.Services;
using SistemaGestionDTO;
using SistemaGestionEntities.models;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {

        private readonly UserService _UserService;

        public UsuarioController(UserService userService)
        {
            _UserService = userService;
        }

        [HttpGet]
        public IActionResult ObtenerListadoUsuarios()
        {
            List<Usuario> usuarios = this._UserService.GetAllUsers();
            return Ok(new { message = "List of users retrieved successfully", usuarios = usuarios });
        }


        [HttpPost]
        public IActionResult AgregarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (this._UserService.AddUser(usuarioDTO))
            {
                return base.Ok(new { message = "Your user were created successfully", usuario = usuarioDTO});

            }
            else
            {
                return base.Conflict(new { message = "Could not create user"});
            }

        }

        [HttpPut]

        public IActionResult ActualizarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            Usuario? usuario = this._UserService.GetUserById(usuarioDTO.Id);

            if (usuario != null)
            {
                this._UserService.UpdateUser(usuarioDTO.Id, usuarioDTO);
                return base.Ok(new { message = "Your data user were updated successfully", usuario = usuario });
            }
            else
            {
                return base.Conflict(new { message = "Could not updated data user" });
            }
        }

        [HttpGet("{nombreDeUsuario}")]
        public Usuario TraerUsuario(string nombreDeUsuario)
        {
            Usuario usuario = this._UserService.GetUserByUserName(nombreDeUsuario);

            return usuario;

        }





        [HttpGet("{usuario}/{password}")]
        public IActionResult ObtenerUsuarioPassword(string usuario, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password) || usuario == ":usuario" || password == ":password")
                {
                    return base.BadRequest(new { message = "Username and password are required" });
                }
                Usuario findUser = this._UserService.GetUserByUsernameAndPassword(usuario, password);


                if (findUser != null)
                {
                    return base.Ok(new { message = "Successful login", status = 200, id = findUser.Id, nombre = findUser.Nombre, apellido = findUser.Apellido, nombreUsuario = findUser.NombreUsuario, constraseña = findUser.Contraseña, mail = findUser.Mail, productos = findUser.Productos, ventas = findUser.Venta  });
                }
                else
                {
                    return base.Conflict(new { menssage = "Could not login", status = 400 });
                }
            }
            catch (Exception ex) 
            {
                return base.StatusCode(500, new { message = "Internal server error", exception = ex.ToString()});
            }
        }


        [HttpDelete("{idUsuario}")]

        public IActionResult EliminarUsuario(int idUsuario)
        {
            try
            {
                if (idUsuario >= 0)
                {
                    if (this._UserService.DeleteUser(idUsuario) != null)
                    {
                        return base.Ok(new { message = $"The User with id:{idUsuario}, has been deleted", status = 200 });
                    }
                    
                    return base.NotFound();
                }
                else
                {
                    return base.BadRequest(new { message = "User id not valid" });
                }
            }
            catch (Exception ex)
            {
                return base.StatusCode(500, new { message = "Internal server error", exception = ex.ToString() });
            }
        }
    }
}
