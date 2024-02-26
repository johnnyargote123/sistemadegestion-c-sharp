using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.Interfaces
{
    public interface IProductsSoldRepository
    {
        ProductoVendido GetById(int id);
        List<ProductoVendido> GetListByProductId(int productId);
        IEnumerable<ProductoVendido> GetAll();
        bool Add(ProductoVendido productSold);
        int Delete(int id);

        bool Update(int id, ProductoVendido productSold);
    }
}
