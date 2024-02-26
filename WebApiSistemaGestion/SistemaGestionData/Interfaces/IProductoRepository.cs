using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.Interfaces
{
    public interface IProductoRepository
    {
        Producto GetById(int id);
        List<Producto> GetByUserId(int userId);
        IEnumerable<Producto> GetAll();
        bool Add(Producto producto);
        bool Delete(int id);
        bool Update(int? id, Producto producto);
        bool Update(Producto product);
    }
}
