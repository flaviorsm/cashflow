using CFM.Domain.Entities;

namespace CFM.Domain.Interfaces.Repositories
{
    public interface IConsolidadoRepository
    {
        /// <summary>
        /// Adiciona um novo Lançamento ao banco de dados.
        /// </summary>
        /// <param name="consolidado">O objeto <see cref="consolidado"/> a ser adicionado.</param>
        /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
        Task Create(Consolidado consolidado);
    }
}
