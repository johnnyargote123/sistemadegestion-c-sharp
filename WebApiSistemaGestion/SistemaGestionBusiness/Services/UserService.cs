using SistemaGestionData.Interfaces;
using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData.Repositories;
using SistemaGestionDTO;
using SistemaGestionMapper;

namespace SistemaGestionBusiness.Services
{
    public class UserService
    {

        private readonly IUserRepository _userRepository;
        private readonly UserMapper _userMapper;

        public UserService(IUserRepository userRepository, UserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }


        public Usuario? GetUserById(int id)
        {
            return _userRepository.GetById(id); 
        }

        public Usuario? GetUserByUserName(string userName) 
        {
            return _userRepository.GetByUserName(userName);
        }


        public Usuario GetUserByUsernameAndPassword(string username, string password)
        {
            try
            {

                //Usuario? usuario = _userRepository.GetAll().Where(u => u.NombreUsuario == username && u.Contraseña == password).FirstOrDefault();
                Usuario? usuario = this.GetUserByUserName(username);

                    if (usuario != null)
                    {
                        if (usuario.Contraseña == password)
                        {
                            return usuario;
                        }
                    }
                    else
                    {
                        return null;
                    }
                return null;
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while logging session:", ex);
            }
        }

        public List<Usuario> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public bool AddUser(UsuarioDTO userDTO)
        {
            try
            {
               Usuario usuario =  _userMapper.UserToMapper(userDTO);

                if (_userRepository.Add(usuario))
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the User:", ex);
            }
        }

        public int DeleteUser(int id)
        {
                int resultDeleteUser = _userRepository.Delete(id);
                return resultDeleteUser;
  
        }

        public bool UpdateUser(int id, UsuarioDTO userDTO)
        {
            try
            {
                if (id != -1)
                {
                    Usuario usuario = _userMapper.UserToMapper(userDTO);
                    if (_userRepository.Update(id, usuario))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the user:", ex);
            }
        }

       

    }
}
