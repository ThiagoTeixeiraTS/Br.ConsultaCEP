using Br.ConsultaCEP.Context;
using Br.ConsultaCEP.Models;
using Br.ConsultaCEP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Br.ConsultaCEP.Services
{
    public class CepService
    {
        private readonly CepContext _context;
        private readonly CepRepository _repository;


        public CepService(CepContext context)
        {
            _context = context;
            _repository = new CepRepository(_context);
        }

        public async Task<List<Cep>> List()
        {
            return  await _repository.List();  
        }

        public async Task<Cep> Save(Cep cep)
        {

            if (cep == null)
                return new Cep();

            var consult =  _repository.GetByCep(cep);

            if(consult)
                return new Cep();

            return await _repository.Save(cep);
        }



    }
}
