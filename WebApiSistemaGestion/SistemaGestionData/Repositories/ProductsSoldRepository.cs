using SistemaGestionEntities.models;
using SistemaGestionData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.Repositories
{
    public class ProductsSoldRepository: IProductsSoldRepository
    {

        private readonly IDatabaseContextFactory _contextFactory;

        public ProductsSoldRepository(IDatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }


        public ProductoVendido GetById(int id)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    ProductoVendido? productsSold = _context.ProductoVendidos.FirstOrDefault(ps => ps.Id == id);

                    if (productsSold == null)
                    {
                        throw new Exception("product Sold not found with the specified ID.");
                    }

                    return productsSold;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product Sold by ID.", ex);
            }

        }

        public List<ProductoVendido> GetListByProductId(int productId)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    List<ProductoVendido> productsSoldList = _context.ProductoVendidos.Where(ps => ps.IdProducto == productId).ToList();

                    if (productsSoldList == null)
                    {
                        throw new Exception("product Sold not found with the specified ID.");
                    }

                    return productsSoldList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product Sold by ID.", ex);
            }

        }


        public IEnumerable<ProductoVendido> GetAll()
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    IEnumerable<ProductoVendido> productsSoldList = _context.ProductoVendidos.ToList();

                    if (productsSoldList.Count() == 0)
                    {
                        throw new Exception("The list of products Sold is empty.");
                    }

                    return productsSoldList;
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products Sold.", ex);
            }
        }

        public bool Add(ProductoVendido productSold)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    if (productSold != null)
                    {
                        _context.ProductoVendidos.Add(productSold);
                        int _productSoldSaved = _context.SaveChanges();
                        if (_productSoldSaved > 0)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                        throw new Exception("product Sold cannot be null");
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the product Sold:", ex);

            }
        }

        public int Delete(int id)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {


                    var productSoldToDelete = _context.ProductoVendidos.FirstOrDefault(ps => ps.Id == id);

                    if (productSoldToDelete != null)
                    {
                        _context.ProductoVendidos.Remove(productSoldToDelete);
                        _context.SaveChanges();
                        return id;
                    }
                    else
                    {
                        throw new Exception("No product Sold found with the provided ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while delete the product Sold:", ex);

            }

        }

        public bool Update(int id, ProductoVendido productSold)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    var existingProductSold = _context.ProductoVendidos.FirstOrDefault(ps => ps.Id == id);

                    if (existingProductSold != null)
                    {
                        existingProductSold.Stock = productSold.Stock;
                        existingProductSold.IdProducto = productSold.IdProducto;
                        existingProductSold.IdVenta = productSold.IdVenta;

                        _context.SaveChanges();
                        return true;
                    }

                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while update the product Sold:", ex);
            }
        }
    }
}
