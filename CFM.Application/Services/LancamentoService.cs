using CFM.Domain.Entities;
using CFM.Domain.Interfaces;
using CFM.Domain.Interfaces.Repositories;

namespace CFM.Domain.Services
{
    public class LancamentoService(ILancamentoRepository lancamentoRepository) : ILancamentoService
    {
        public Task Create(Lancamento lancamento)
        {
            return lancamentoRepository.Create(lancamento);
        }

        public Task Delete(int id)
        {
            return lancamentoRepository.Delete(id);
        }

        public Task<IList<Lancamento>> GetAll()
        {
            return lancamentoRepository.GetAll();
        }

        public Task<Lancamento?> GetById(int id)
        {
            return lancamentoRepository.GetById(id);
        }

        public Task Update(Lancamento lancamento)
        {
            return lancamentoRepository.Update(lancamento);
        }
    }
}
