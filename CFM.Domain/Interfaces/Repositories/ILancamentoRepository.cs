using CFM.Domain.Entities;
using CFM.Domain.Enums;

namespace CFM.Domain.Interfaces.Repositories
{
    public interface ILancamentoRepository
    {
        /// <summary>
        /// Adiciona um novo Lançamento ao banco de dados.
        /// </summary>
        /// <param name="lancamento">O objeto <see cref="Lancamento"/> a ser adicionado.</param>
        /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
        Task Create(Lancamento lancamento);

        /// <summary>
        /// Remove um Lançamento pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do Lançamento a ser removido.</param>
        /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
        Task Delete(int id);

        /// <summary>
        /// Atualiza um Lançamento existente no banco de dados.
        /// </summary>
        /// <param name="lancamento">O objeto <see cref="Lancamento"/> a ser atualizado.</param>
        /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
        Task Update(Lancamento lancamento);

        /// <summary>
        /// Obtém todos os Lançamentos.
        /// </summary>
        /// <returns>Uma lista de <see cref="Lancamento"/> contendo todos os lançamentos.</returns>
        Task<IList<Lancamento>> GetAll();

        /// <summary>
        /// Obtém um Lançamento pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do Lançamento a ser obtido.</param>
        /// <returns>Um <see cref="Lancamento"/> correspondente ao ID fornecido.</returns>
        Task<Lancamento?> GetById(int id);

        /// <summary>
        /// Obtém uma lista de lançamentos filtrados por um período de tempo.
        /// </summary>
        /// <param name="startDate">Data inicial do período.</param>
        /// <param name="endDate">Data final do período.</param>
        /// <param name="category">Categoria dos lançamentos a serem filtrados.</param>
        /// <returns>Uma lista de objetos <see cref="Lancamento"/> que estão dentro do período e correspondem à categoria especificada.</returns>
        Task<IList<Lancamento>> GetByPeriod(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Obtém uma lista de lançamentos filtrados por um período de tempo e uma categoria específica.
        /// </summary>
        /// <param name="startDate">Data inicial do período para filtrar os lançamentos.</param>
        /// <param name="endDate">Data final do período para filtrar os lançamentos.</param>
        /// <param name="category">Categoria dos lançamentos a serem filtrados.</param>
        /// <returns>Uma lista de objetos <see cref="Lancamento"/> que correspondem ao período e à categoria especificados.</returns>
        Task<IList<Lancamento>> GetByCategory(DateTime startDate, DateTime endDate, CategoriaEnum? category);

        /// <summary>
        /// Obtém uma lista de lançamentos para uma data específica.
        /// </summary>
        /// <param name="date">Data para a qual os lançamentos serão filtrados.</param>
        /// <returns>Uma lista de objetos <see cref="Lancamento"/> que correspondem à data fornecida.</returns>
        Task<IList<Lancamento>> GetByDate(DateTime date);
    }
}
