using SistemaGestionData.dataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.Interfaces
{
    public interface IDatabaseContextFactory
    {
        CoderContext CreateDbContext();
    }
}
