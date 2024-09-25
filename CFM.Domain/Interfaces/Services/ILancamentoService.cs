using CFM.Domain.Entities;

namespace CFM.Domain.Interfaces
{
    public interface ILancamentoService
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
    }
}
