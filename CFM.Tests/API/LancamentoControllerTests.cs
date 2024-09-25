using AutoMapper;
using CFM.Api.Controllers;
using CFM.Application.DTOs;
using CFM.Domain.Entities;
using CFM.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CFM.Tests.API
{
    public class LancamentoControllerTests
    {
        private readonly LancamentoController _controller;
        private readonly Mock<ILancamentoService> _lancamentoServiceMock;
        private readonly IMapper _mapper;

        public LancamentoControllerTests()
        {
            _lancamentoServiceMock = new Mock<ILancamentoService>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Lancamento, LancamentoDTO>();
                cfg.CreateMap<LancamentoDTO, Lancamento>();
            });
            _mapper = config.CreateMapper();
            _controller = new LancamentoController(_lancamentoServiceMock.Object, _mapper);
        }

        [Fact]
        public async Task Create_ValidLancamentoDTO_ReturnsCreatedAtAction()
        {
            // Arrange
            var lancamentoDTO = new LancamentoDTO { /* Propriedades válidas */ };
            var lancamento = new Lancamento { Id = 1 }; // Simulando um lançamento criado
            _lancamentoServiceMock.Setup(service => service.Create(It.IsAny<Lancamento>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(lancamentoDTO);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
            Assert.Equal(lancamento.Id, ((Lancamento)createdResult.Value).Id);
        }

        [Fact]
        public async Task Delete_ExistingId_ReturnsOk()
        {
            // Arrange
            int existingId = 1;
            _lancamentoServiceMock.Setup(service => service.Delete(existingId)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(existingId);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task Update_ValidLancamentoDTO_ReturnsCreatedAtAction()
        {
            // Arrange
            var lancamentoDTO = new LancamentoDTO { Id = 1 /* Propriedades válidas */ };
            var lancamento = new Lancamento { Id = 1 };
            _lancamentoServiceMock.Setup(service => service.Update(It.IsAny<Lancamento>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(lancamentoDTO);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WhenLançamentosExist()
        {
            // Arrange
            var lancamentos = new List<Lancamento>
            {
                new Lancamento { Id = 1 },
                new Lancamento { Id = 2 }
            };
            _lancamentoServiceMock.Setup(service => service.GetAll()).ReturnsAsync(lancamentos);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<LancamentoDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public async Task GetById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            int existingId = 1;
            var lancamento = new Lancamento { Id = existingId };
            _lancamentoServiceMock.Setup(service => service.GetById(existingId)).ReturnsAsync(lancamento);

            // Act
            var result = await _controller.GetById(existingId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<LancamentoDTO>(okResult.Value);
            Assert.Equal(existingId, returnValue.Id);
        }

        [Fact]
        public async Task GetById_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingId = 999;
            _lancamentoServiceMock.Setup(service => service.GetById(nonExistingId)).ReturnsAsync((Lancamento)null);

            // Act
            var result = await _controller.GetById(nonExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
