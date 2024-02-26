using SistemaGestionEntities.models;
using SistemaGestionData.ContextFactory;
using SistemaGestionData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IDatabaseContextFactory _contextFactory;

        public UserRepository(IDatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Usuario GetById(int id)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    Usuario? user = _context.Usuarios.FirstOrDefault(u => u.Id == id);

                    if (user == null)
                    {
                        throw new Exception("User not found with the specified ID.");
                    }

                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user by ID.", ex);
            }

        }

        public Usuario GetByUserName(string userName)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    Usuario? user = _context.Usuarios.Where(u => u.NombreUsuario == userName).FirstOrDefault();

                    if (user == null)
                    {
                        throw new Exception("User not found with the specified userName.");
                    }

                    return user;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user by userName.", ex);
            }
        }
        public List<Usuario> GetAll()
        {
            try
            {
                using(var _context = _contextFactory.CreateDbContext()) 
                {
                    List<Usuario> userList = _context.Usuarios.ToList();

                    if (userList.Count() == 0)
                    {
                        throw new Exception("The list of products is empty.");
                    }

                    return userList;
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user.", ex);
            }
        }

        public bool Add(Usuario user)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    if (user != null)
                    {
                        _context.Usuarios.Add(user);
                        int _prodcutSaved = _context.SaveChanges();
                        if (_prodcutSaved > 0)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                        throw new Exception("User cannot be null");
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the User:", ex);

            }
        }

        public int Delete(int id)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {


                    var UserToDelete = _context.Usuarios.FirstOrDefault(u => u.Id == id);

                    if (UserToDelete != null)
                    {
                        _context.Usuarios.Remove(UserToDelete);
                        _context.SaveChanges();
                        return id;
                    }
                    else
                    {
                        throw new Exception("No user found with the provided ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while delete the user:", ex);

            }

        }

        public bool Update(int id, Usuario user)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    var existingUser = _context.Usuarios.FirstOrDefault(u => u.Id == id);

                    if (existingUser != null)
                    {
                        existingUser.Nombre= user.Nombre;
                        existingUser.Apellido = user.Apellido;
                        existingUser.NombreUsuario = user.NombreUsuario;
                        existingUser.Contraseña = user.Contraseña;
                        existingUser.Mail = user.Mail;

                        _context.Usuarios.Update(existingUser);
                        _context.SaveChanges();
                        return true;
                    }

                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while update the product:", ex);
            }
        }

    }
}
