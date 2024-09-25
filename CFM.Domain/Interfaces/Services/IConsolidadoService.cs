using CFM.Domain.Entities;
using CFM.Domain.Enums;

namespace CFM.Domain.Interfaces.Services
{
    public interface IConsolidadoService
    {
        /// <summary>
        /// Consolida os lançamentos de um dia específico.
        /// </summary>
        /// <param name="data">A data para a qual os lançamentos serão consolidados.</param>
        /// <returns>
        /// Um objeto <see cref="Consolidado"/> contendo o resumo dos lançamentos do dia especificado.
        /// </returns>
        /// <remarks>
        /// Este método consolida todos os lançamentos de uma data específica, somando receitas e despesas,
        /// e retornando um objeto consolidado com os totais e os detalhes dos lançamentos.
        /// </remarks>
        Task<Consolidado> ConsolidarPorDia(DateTime data);

        /// <summary>
        /// Consolida os lançamentos dentro de um período de tempo, com a opção de filtrar por categoria.
        /// </summary>
        /// <param name="dataInicial">A data inicial do período para a consolidação.</param>
        /// <param name="dataFinal">A data final do período para a consolidação.</param>
        /// <param name="categoria">
        /// A categoria opcional para filtrar os lançamentos. 
        /// Se não for fornecida, a consolidação será feita para todas as categorias.
        /// </param>
        /// <returns>
        /// Um objeto <see cref="Consolidado"/> contendo o resumo dos lançamentos no período especificado.
        /// </returns>
        /// <remarks>
        /// Este método consolida todos os lançamentos em um determinado período, somando receitas e despesas.
        /// Se uma categoria for fornecida, a consolidação será filtrada por essa categoria; caso contrário, 
        /// todos os lançamentos no período serão considerados.
        /// </remarks>
        Task<Consolidado> ConsolidarPorPeriodo(DateTime dataInicial, DateTime dataFinal, CategoriaEnum? categoria = null);

    }
}
