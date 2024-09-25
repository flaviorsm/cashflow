using AutoMapper;
using CFM.Application.DTOs;
using CFM.Domain.Entities;
using CFM.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CFM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")] 
    public class LancamentoController(ILancamentoService lancamentoService, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Cria um novo lançamento.
        /// </summary>
        /// <param name="lancamentoDTO">Objeto lançamento a ser criado.</param>
        /// <returns>O lançamento criado.</returns>
        /// <response code="201">Retorna o lançamento recém-criado.</response>
        /// <response code="400">Se os dados fornecidos forem inválidos.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create(LancamentoDTO lancamentoDTO)
        {
            try
            {
                var lancamento = mapper.Map<Lancamento>(lancamentoDTO);
                await lancamentoService.Create(lancamento);
                return CreatedAtAction(nameof(GetById), new { id = lancamento.Id }, lancamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um lançamento.
        /// </summary>
        /// <param name="id">ID do lançamento a ser excluído.</param>
        /// <returns>Sem conteúdo, indicando sucesso.</returns>
        /// <response code="204">Lançamento excluído com sucesso.</response>
        /// <response code="404">Se o lançamento não for encontrado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await lancamentoService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Atualiza um lançamento existente.
        /// </summary>
        /// <param name="lancamentoDTO">Objeto lançamento com as atualizações.</param>
        /// <returns>Sem conteúdo, indicando sucesso.</returns>
        /// <response code="204">Lançamento atualizado com sucesso.</response>
        /// <response code="400">Se os dados fornecidos forem inválidos.</response>
        /// <response code="404">Se o lançamento não for encontrado.</response>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(LancamentoDTO lancamentoDTO)
        {
            try
            {
                var lancamento = mapper.Map<Lancamento>(lancamentoDTO);
                await lancamentoService.Update(lancamento);
                return CreatedAtAction(nameof(GetById), new { id = lancamento.Id }, lancamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtém todos os lançamentos.
        /// </summary>
        /// <returns>Lista de lançamentos.</returns>
        /// <response code="200">Retorna a lista de lançamentos.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lancamentos = await lancamentoService.GetAll();
                if (lancamentos.Count == 0)
                    return NoContent();

                return Ok(lancamentos);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtém um lançamento pelo ID.
        /// </summary>
        /// <param name="id">ID do lançamento.</param>
        /// <returns>O lançamento correspondente ao ID fornecido.</returns>
        /// <response code="200">Retorna o lançamento solicitado.</response>
        /// <response code="404">Se o lançamento não for encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var lancamento = await lancamentoService.GetById(id);
                if (lancamento == null)
                    return NotFound();

                var lancamentoDTO = mapper.Map<LancamentoDTO>(lancamento);

                return Ok(lancamentoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
