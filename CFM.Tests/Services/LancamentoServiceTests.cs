using CFM.Domain.Entities;
using CFM.Domain.Interfaces.Repositories;
using CFM.Domain.Services;
using Moq;

namespace CFM.Tests.Services
{
    public class LancamentoServiceTests
    {
        private readonly LancamentoService _service;
        private readonly Mock<ILancamentoRepository> _lancamentoRepositoryMock;

        public LancamentoServiceTests()
        {
            _lancamentoRepositoryMock = new Mock<ILancamentoRepository>();
            _service = new LancamentoService(_lancamentoRepositoryMock.Object);
        }

        [Fact]
        public async Task Create_ValidLancamento_CallsRepositoryCreate()
        {
            var lancamento = new Lancamento { Id = 1 };

            await _service.Create(lancamento);

            _lancamentoRepositoryMock.Verify(repo => repo.Create(lancamento), Times.Once);
        }

        [Fact]
        public async Task Delete_ExistingId_CallsRepositoryDelete()
        {
            int existingId = 1;

            await _service.Delete(existingId);

            _lancamentoRepositoryMock.Verify(repo => repo.Delete(existingId), Times.Once);
        }

        [Fact]
        public async Task GetAll_ReturnsListOfLancamentos()
        {
            var lancamentos = new List<Lancamento>
            {
                new Lancamento { Id = 1 },
                new Lancamento { Id = 2 }
            };
            _lancamentoRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(lancamentos);

            var result = await _service.GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetById_ExistingId_ReturnsLancamento()
        {
            int existingId = 1;
            var lancamento = new Lancamento { Id = existingId };
            _lancamentoRepositoryMock.Setup(repo => repo.GetById(existingId)).ReturnsAsync(lancamento);

            var result = await _service.GetById(existingId);

            Assert.NotNull(result);
            Assert.Equal(existingId, result?.Id);
        }

        [Fact]
        public async Task GetById_NonExistingId_ReturnsNull()
        {
            int nonExistingId = 999;
            _lancamentoRepositoryMock.Setup(repo => repo.GetById(nonExistingId)).ReturnsAsync((Lancamento)null);

            var result = await _service.GetById(nonExistingId);

            Assert.Null(result);
        }

        [Fact]
        public async Task Update_ValidLancamento_CallsRepositoryUpdate()
        {
            var lancamento = new Lancamento { Id = 1 };

            await _service.Update(lancamento);

            _lancamentoRepositoryMock.Verify(repo => repo.Update(lancamento), Times.Once);
        }
    }
}
