using SistemaGestionEntities.models;
using SistemaGestionData.Interfaces;
using SistemaGestionData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionDTO;
using SistemaGestionMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SistemaGestionBusiness.Services
{
    public class SaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly SaleMapper _saleMapper;
        private readonly ProductsSoldService _productsSoldService;
        private readonly ProductService _productService;

        public SaleService(ISaleRepository saleRepository, SaleMapper saleMapper, ProductsSoldService productsSoldService ,ProductService productService)
        {
            _saleRepository = saleRepository;
            _saleMapper = saleMapper;
            _productsSoldService = productsSoldService;
            _productService = productService;
        }

        public Venta? GetSaleById(int id)
        {
            return _saleRepository.GetById(id);
        }

        public List<VentaDTO> GetSaleByUserId(int userId)
        {
            List<Venta> venta = this._saleRepository.GetByUserId(userId);
            List<VentaDTO> ventaDTO = this._saleMapper.ListSaleDTOToMapper(venta);
            return ventaDTO;
        }

        public List<Venta> GetAllSales()
        {
            return _saleRepository.GetAll();
        }


        public bool AddSale(int userId, List<ProductoDTO> productDTO)
        {
            try
            {
                Venta venta = new Venta();
                List<string> nombresDeProductos = productDTO.Select(product => product.Descripciones).ToList();
                string comentarios = string.Join(",", nombresDeProductos);
                venta.Comentarios = comentarios;
                venta.IdUsuario = userId;

                bool isSaleAdded = this._saleRepository.Add(venta);

                if (isSaleAdded)
                {
                    this.CheckLikeSoldProduct(productDTO, venta.Id);
                    this.UpdateStockProductSold(productDTO);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the sale:", ex);
            }
        }

        public void CheckLikeSoldProduct(List<ProductoDTO> productosDTO, int idVenta)
        {
            productosDTO.ForEach(producto =>
            {
                ProductoVendidoDTO productoVendidoDTO = new ProductoVendidoDTO();
                productoVendidoDTO.IdProducto = producto.Id;
                productoVendidoDTO.IdVenta = idVenta;
                productoVendidoDTO.Stock = producto.Stock;
                this._productsSoldService.AddProductsSold(productoVendidoDTO);

            });
        }

        public void UpdateStockProductSold (List<ProductoDTO> productosDTO)
        {
            productosDTO.ForEach(producto =>
            {
                ProductoDTO productoActual =   this._productService.GetProductById(producto.Id);
                productoActual.Stock -= producto.Stock;
                this._productService.UpdateProduct(productoActual);
            });

        }

        public int DeleteSale(int id)
        {
            if (id != -1)
            {
                int resultDeleteSale = _saleRepository.Delete(id);
                Console.WriteLine(resultDeleteSale);
                return resultDeleteSale;
            }
            else
            {
                throw new Exception("Could not delete sale");
            }
        }

        public bool UpdateSale(int id, Venta sale)
        {
            try
            {
                if (id != -1)
                {
                    if (_saleRepository.Update(id, sale))
                    {
                        Console.WriteLine(sale.FullDataSale());
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the sale:", ex);
            }
        }



    }
}
