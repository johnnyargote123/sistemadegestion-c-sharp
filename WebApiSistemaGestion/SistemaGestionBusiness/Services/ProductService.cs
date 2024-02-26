using SistemaGestionData.Interfaces;
using SistemaGestionEntities.models;
using SistemaGestionData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionMapper;
using SistemaGestionDTO;

namespace SistemaGestionBusiness.Services
{
    public class ProductService
    {
        private readonly IProductoRepository _productRepository;
        private readonly ProductMapper _productMapper;

        public ProductService(IProductoRepository productRepository, ProductMapper productMapper)
        {
            _productRepository = productRepository;
            _productMapper = productMapper;
        }

        public ProductoDTO? GetProductById(int id)
        {
            ProductoDTO productoDTO = this._productMapper.ProductDTOToMapper(this._productRepository.GetById(id));
            return productoDTO;
        }

        public List<ProductoDTO> GetProductByUserId(int userId)
        {
            List<Producto> producto = _productRepository.GetByUserId(userId);
            List<ProductoDTO> productoDTO = this._productMapper.ListProductDTOToMapper(producto);
            return productoDTO;
        }

        public IEnumerable<Producto> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public bool AddProduct(ProductoDTO productDTO)
        {
            try
            {
                Producto product = this._productMapper.ProductToMapper(productDTO);
                if (_productRepository.Add(product))
                {
                    return true;
                }
                return false;
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the product:", ex);
            }
        }


        public bool DeleteProduct(int id)
        {

            bool resultDeleteProduct = _productRepository.Delete(id);
            return resultDeleteProduct;

        }

        public bool UpdateProduct(int? id , ProductoDTO productDTO)
        {
            try
            {
               Producto product = this._productMapper.ProductToMapper(productDTO);
                if (id != -1)
                {
                        if (_productRepository.Update(id,product))
                        {
                            return true;
                        }
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception("An error occurred while updating the product:", ex);
            }
        }

        public bool UpdateProduct(ProductoDTO productDTO)
        {
            try
            {
                Producto product = this._productMapper.ProductToMapper(productDTO);

                if (_productRepository.Update(product))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the product:", ex);
            }
        }
    }

}
