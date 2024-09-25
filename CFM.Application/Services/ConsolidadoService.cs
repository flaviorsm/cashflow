using CFM.Domain.Entities;
using CFM.Domain.Enums;
using CFM.Domain.Interfaces.Repositories;
using CFM.Domain.Interfaces.Services;

namespace CFM.Application.Services
{
    public class ConsolidadoService(ILancamentoRepository lancamentoRepository) : IConsolidadoService
    {
        public async Task<Consolidado> ConsolidarPorDia(DateTime data)
        {
            var lancamentos = await lancamentoRepository.GetByDate(data);

            Consolidado consolidado = new() { DataInicio = data, DataFim = data };
            foreach (Lancamento lancamento in lancamentos)
            {                
                consolidado.ValorDespesas += lancamento.Categoria == CategoriaEnum.Despesa ? lancamento.Valor : 0;
                consolidado.ValorReceitas += lancamento.Categoria == CategoriaEnum.Receita ? lancamento.Valor : 0;
            }
            consolidado.ValorTotal = consolidado.ValorReceitas - consolidado.ValorDespesas;
            return consolidado;
        }

        public async Task<Consolidado> ConsolidarPorPeriodo(DateTime dataInicio, DateTime dataFim, CategoriaEnum? categoria = null)
        {
            IList<Lancamento> lancamentos = [];
            if (categoria == null)
            {
                lancamentos = await lancamentoRepository.GetByPeriod(dataInicio, dataFim);
            } 
            else
            {
                lancamentos = await lancamentoRepository.GetByCategory(dataInicio, dataFim, categoria);
            }

            Consolidado consolidado = new() { DataInicio = dataInicio, DataFim = dataFim };
            foreach (Lancamento lancamento in lancamentos)
            {
                switch (categoria)
                {
                    case CategoriaEnum.Despesa:
                        consolidado.ValorDespesas += lancamento.Valor;
                        break;

                    case CategoriaEnum.Receita:
                        consolidado.ValorReceitas += lancamento.Valor;
                        break;
                        
                    default:
                        consolidado.ValorDespesas += lancamento.Categoria == CategoriaEnum.Despesa ? lancamento.Valor : 0;
                        consolidado.ValorReceitas += lancamento.Categoria == CategoriaEnum.Receita ? lancamento.Valor : 0;
                        break;
                }                
            }

            return consolidado;            
        }
    }
}
