using Br.ConsultaCEP.Context;
using Br.ConsultaCEP.Models;
using Microsoft.EntityFrameworkCore;

namespace Br.ConsultaCEP.Repositories
{
    public class CepRepository : ICepRepository
    {


        public readonly CepContext _context;
        public CepRepository(CepContext context)
        {
            _context = context;
        }

        public bool GetByCep(Cep cep)
        {
            return _context.Cep.Where(c => c.CEP == cep.CEP).Count() > 0 ; 
        }

        public async Task<List<Cep>> List()
        {
            return await _context.Cep.AsNoTracking().ToListAsync();
        }

        public async Task<Cep> Save(Cep cep)
        {
            _context.Cep.Add(cep);
            await _context.SaveChangesAsync();

            return cep;
        }
    }
}
