using SistemaGestionDTO;
using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionMapper
{
    public class UserMapper
    {

        public Usuario UserToMapper(UsuarioDTO dto)
        {
            Usuario usuario = new Usuario();
            usuario.Id = dto.Id;
            usuario.NombreUsuario = dto.NombreUsuario;
            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.Contraseña = dto.Contraseña;
            usuario.Mail = dto.Mail;

            return usuario;
        }

  
    }
}
