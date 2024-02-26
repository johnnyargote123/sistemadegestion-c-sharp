using SistemaGestionEntities.models;
using Microsoft.EntityFrameworkCore;
using SistemaGestionData.ContextFactory;
using SistemaGestionData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.Repositories
{
    public class ProductRepository : IProductoRepository
    {

        private readonly IDatabaseContextFactory _contextFactory;

        public ProductRepository(IDatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public Producto GetById(int id)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    Producto? product = _context.Productos.FirstOrDefault(product => product.Id == id);

                    if (product == null)
                    {
                        throw new Exception("Product not found with the specified ID.");
                    }

                    return product;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product by ID.", ex);
            }

        }

        public List<Producto> GetByUserId(int userId)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    List<Producto> products = _context.Productos.Where(product => product.IdUsuario == userId).ToList();

                    if (products == null)
                    {
                        throw new Exception("Product not found with the specified User ID.");
                    }

                    return products;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product by User ID.", ex);
            }

        }

        public IEnumerable<Producto> GetAll()
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    IEnumerable<Producto> productList = _context.Productos.ToList();

                    if (productList.Count() == 0)
                    {
                        throw new Exception("The list of products is empty.");
                    }

                    return productList;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error retrieving product.", ex);
            }
        }

        public bool Add(Producto product)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    if(product != null)
                    {
                        _context.Productos.Add(product);
                        int _prodcutSaved = _context.SaveChanges();
                        if (_prodcutSaved > 0)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                        throw new Exception("Product cannot be null");
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the product:", ex);
                
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {

                    // es importante hacer esta carga de datos relacionadas cuando voy a hacer un borrado en cascada
                    var productToDelete = _context.Productos.Include(p => p.ProductoVendidos).Where(p => p.Id == id).FirstOrDefault();

                    if (productToDelete != null)
                    {
                        _context.Productos.Remove(productToDelete);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while delete the product:", ex);

            }

        }

        public bool Update(int? id, Producto product)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    var existingProduct = _context.Productos.FirstOrDefault(p => p.Id == id);

                    if (existingProduct != null)
                    {
                        existingProduct.Descripciones = product.Descripciones;
                        existingProduct.Costo = product.Costo;
                        existingProduct.PrecioVenta = product.PrecioVenta;
                        existingProduct.Stock = product.Stock;
                        existingProduct.IdUsuario = product.IdUsuario;

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

        public bool Update(Producto product)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    var existingProduct = _context.Productos.FirstOrDefault(p => p.Id == product.Id);

                    if (existingProduct != null)
                    {
                        existingProduct.Descripciones = product.Descripciones;
                        existingProduct.Costo = product.Costo;
                        existingProduct.PrecioVenta = product.PrecioVenta;
                        existingProduct.Stock = product.Stock;
                        existingProduct.IdUsuario = product.IdUsuario;

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
