using Br.ConsultaCEP.Models;
using Microsoft.EntityFrameworkCore;

namespace Br.ConsultaCEP.Context
{
    public class CepContext : DbContext
    {
        public CepContext(DbContextOptions<CepContext> options) : base(options) { }

        public DbSet<Cep> Cep { get; set; }
    }
}
