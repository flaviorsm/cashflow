using CFM.Domain.Entities;
using CFM.Domain.Enums;
using CFM.Domain.Interfaces;
using CFM.Domain.Interfaces.Repositories;
using CFM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CFM.Infrastructure.Repositories
{
    public class LancamentoRepository(ApplicationDbContext context) : ILancamentoRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Create(Lancamento lancamento)
        {
            await _context.Lancamentos.AddAsync(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Lancamento? lancamento = await GetById(id);
            if (lancamento != null)
            {
                _context.Lancamentos.Remove(lancamento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Lancamento>> GetAll()
        {
            return await _context.Lancamentos.ToListAsync();
        }

        public async Task<IList<Lancamento>> GetByCategory(DateTime startDate, DateTime endDate, CategoriaEnum? category)
        {
            return await _context.Lancamentos
                .Where(l => l.Data >= startDate && l.Data <= endDate && l.Categoria == category)
                .ToListAsync();
        }

        public async Task<IList<Lancamento>> GetByDate(DateTime date)
        {
            return await _context.Lancamentos.Where(l => l.Data == date).ToListAsync();
        }

        public async Task<Lancamento?> GetById(int id)
        {
            return await _context.Lancamentos.FindAsync(id);
        }

        public async Task<IList<Lancamento>> GetByPeriod(DateTime startDate, DateTime endDate)
        {
            return await _context.Lancamentos
                .Where(l => l.Data >= startDate && l.Data <= endDate)
                .ToListAsync();
        }

        public async Task Update(Lancamento lancamento)
        {
            _context.Lancamentos.Update(lancamento);
            await _context.SaveChangesAsync();
        }
    }
}
