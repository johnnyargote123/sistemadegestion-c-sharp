using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SistemaGestionData.dataBase;
using SistemaGestionData.Interfaces;

namespace SistemaGestionData.ContextFactory
{
    public class DatabaseContextFactory : IDatabaseContextFactory
    {
        private readonly DbContextOptions<CoderContext> _options;

        public DatabaseContextFactory(DbContextOptions<CoderContext> options)
        {
            _options = options;
        }
        public CoderContext CreateDbContext()
        {
            return new CoderContext(_options);
        }
    }
}
