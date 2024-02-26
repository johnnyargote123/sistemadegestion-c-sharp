using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.Interfaces
{
    public interface ISaleRepository
    {
        Venta GetById(int id);

        List<Venta> GetByUserId(int userId);
        List<Venta> GetAll();
        bool Add(Venta sale);
        int Delete(int id);

        bool Update(int id, Venta sale);
    }
}
