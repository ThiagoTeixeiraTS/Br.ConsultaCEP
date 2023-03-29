using Br.ConsultaCEP.Models;

namespace Br.ConsultaCEP.Repositories
{
    public interface ICepRepository
    {
        Task<Cep> Save(Cep cep);
        Task<List<Cep>> List();
        bool GetByCep(Cep cep);
    }
}
