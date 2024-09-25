using CFM.Application.Services;
using CFM.Domain.Entities;
using CFM.Domain.Enums;
using CFM.Domain.Interfaces.Repositories;
using Moq;

namespace CFM.Tests.Services
{
    public class ConsolidadoServiceTests
    {
        private readonly ConsolidadoService _service;
        private readonly Mock<ILancamentoRepository> _lancamentoRepositoryMock;

        public ConsolidadoServiceTests()
        {
            _lancamentoRepositoryMock = new Mock<ILancamentoRepository>();
            _service = new ConsolidadoService(_lancamentoRepositoryMock.Object);
        }

        [Fact]
        public async Task ConsolidarPorDia_ValidDate_ReturnsConsolidado()
        {
            var data = new DateTime(2024, 09, 25);
            var lancamentos = new List<Lancamento>
            {
                new Lancamento { Categoria = CategoriaEnum.Despesa, Valor = 100 },
                new Lancamento { Categoria = CategoriaEnum.Receita, Valor = 200 }
            };
            _lancamentoRepositoryMock.Setup(repo => repo.GetByDate(data)).ReturnsAsync(lancamentos);

            var result = await _service.ConsolidarPorDia(data);

            Assert.NotNull(result);
            Assert.Equal(data, result.DataInicio);
            Assert.Equal(data, result.DataFim);
            Assert.Equal(100, result.ValorDespesas);
            Assert.Equal(200, result.ValorReceitas);
            Assert.Equal(100, result.ValorTotal);
        }

        [Fact]
        public async Task ConsolidarPorPeriodo_WithoutCategory_ReturnsConsolidado()
        {
            var dataInicio = new DateTime(2024, 09, 01);
            var dataFim = new DateTime(2024, 09, 30);
            var lancamentos = new List<Lancamento>
            {
                new Lancamento { Categoria = CategoriaEnum.Despesa, Valor = 150 },
                new Lancamento { Categoria = CategoriaEnum.Receita, Valor = 300 },
                new Lancamento { Categoria = CategoriaEnum.Despesa, Valor = 50 }
            };
            _lancamentoRepositoryMock.Setup(repo => repo.GetByPeriod(dataInicio, dataFim)).ReturnsAsync(lancamentos);

            var result = await _service.ConsolidarPorPeriodo(dataInicio, dataFim);

            Assert.NotNull(result);
            Assert.Equal(dataInicio, result.DataInicio);
            Assert.Equal(dataFim, result.DataFim);
            Assert.Equal(200, result.ValorDespesas); 
            Assert.Equal(300, result.ValorReceitas);
            Assert.Equal(100, result.ValorTotal);
        }

        [Fact]
        public async Task ConsolidarPorPeriodo_WithCategory_ReturnsConsolidado()
        {
            var dataInicio = new DateTime(2024, 09, 01);
            var dataFim = new DateTime(2024, 09, 30);
            var lancamentos = new List<Lancamento>
            {
                new Lancamento { Categoria = CategoriaEnum.Despesa, Valor = 200 },
                new Lancamento { Categoria = CategoriaEnum.Receita, Valor = 500 },
                new Lancamento { Categoria = CategoriaEnum.Despesa, Valor = 100 }
            };
            _lancamentoRepositoryMock.Setup(repo => repo.GetByCategory(dataInicio, dataFim, CategoriaEnum.Despesa)).ReturnsAsync(lancamentos);

            var result = await _service.ConsolidarPorPeriodo(dataInicio, dataFim, CategoriaEnum.Despesa);
            
            Assert.NotNull(result);
            Assert.Equal(dataInicio, result.DataInicio);
            Assert.Equal(dataFim, result.DataFim);
            Assert.Equal(300, result.ValorDespesas); 
            Assert.Equal(0, result.ValorReceitas);
            Assert.Equal(-300, result.ValorTotal); 
        }
    }
}
