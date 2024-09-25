using AutoMapper;
using CFM.Domain.Entities;
using CFM.Domain.Enums;
using CFM.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CFM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ConsolidadoController(IConsolidadoService consolidadoService, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Consolida os lançamentos para uma data específica.
        /// </summary>
        /// <param name="data">A data para a qual a consolidação será feita.</param>
        /// <returns>
        /// Retorna o consolidado dos lançamentos do dia especificado.
        /// </returns>
        /// <response code="200">Retorna o consolidado dos lançamentos para o dia solicitado.</response>
        /// <response code="204">Indica que não há lançamentos para a data fornecida.</response>
        /// <response code="400">Se ocorrer um erro de validação ou entrada inválida.</response>
        /// <response code="500">Se ocorrer um erro interno no servidor.</response>
        [HttpGet("PorDia")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ConsolidarPorDia([FromQuery] DateTime data)
        {
            try
            {
                var consolidado = await consolidadoService.ConsolidarPorDia(data);
                if (consolidado == null)
                    return NoContent();

                var consolidadoDTO = mapper.Map<ConsolidadoDTO>(consolidado);

                return Ok(consolidadoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Consolidar os lancamento em um intervalo.
        /// </summary>
        /// <param name="dataInicial">A data inicial do período para a consolidação.</param>
        /// <param name="dataFinal">A data final do período para a consolidação.</param>
        /// <returns>
        /// Retorna um objeto <see cref="IActionResult"/> que pode representar:
        /// <list type="bullet">
        /// <item><description>200 OK: Dados consolidados, se encontrados.</description></item>
        /// <item><description>204 No Content: Se não houver dados disponíveis para o período especificado.</description></item>
        /// <item><description>400 Bad Request: Em caso de erro ao processar a solicitação.</description></item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// Este método captura exceções e retorna uma mensagem de erro em caso de falha.
        /// Os parâmetros <paramref name="dataInicial"/> e <paramref name="dataFinal"/> são obrigatórios e devem estar em formato <c>DateTime</c>.
        /// </remarks>
        [HttpGet("PorPeriodo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ConsolidarPorPeriodo([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal)
        {
            try
            {
                var consolidado = await consolidadoService.ConsolidarPorPeriodo(dataInicial, dataFinal);
                if (consolidado == null)
                    return NoContent();

                var consolidadoDTO = mapper.Map<ConsolidadoDTO>(consolidado);

                return Ok(consolidadoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        /// Consolidar os lançamentos de uma categoria específica em um intervalo de datas.
        /// </summary>
        /// <param name="categoria">O identificador da categoria para a consolidação.</param>
        /// <param name="dataInicial">A data inicial do período para a consolidação.</param>
        /// <param name="dataFinal">A data final do período para a consolidação.</param>
        /// <returns>
        /// Retorna um objeto <see cref="IActionResult"/> que pode representar:
        /// <list type="bullet">
        /// <item><description>200 OK: Dados consolidados, se encontrados.</description></item>
        /// <item><description>204 No Content: Se não houver dados disponíveis para o período e categoria especificados.</description></item>
        /// <item><description>400 Bad Request: Em caso de erro ao processar a solicitação.</description></item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// Este método captura exceções e retorna uma mensagem de erro em caso de falha.
        /// Os parâmetros <paramref name="categoria"/>, <paramref name="dataInicial"/> e <paramref name="dataFinal"/> são obrigatórios e devem estar em formato adequado.
        /// </remarks>
        [HttpGet("PorCategoria")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ConsolidarPorCategoria([FromQuery] int categoria, [FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal)
        {
            try
            {
                var consolidado = await consolidadoService.ConsolidarPorPeriodo(dataInicial, dataFinal, (CategoriaEnum)categoria);
                if (consolidado == null)
                    return NoContent();

                var consolidadoDTO = mapper.Map<ConsolidadoDTO>(consolidado);

                return Ok(consolidadoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
