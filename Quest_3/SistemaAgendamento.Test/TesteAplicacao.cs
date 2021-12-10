using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SistemaAgendamento.Core.Commands;
using SistemaAgendamento.Core.Models;
using SistemaAgendamento.Infrastructure;
using SistemaAgendamento.Service.Handlers;
using SistemaAgendamento.Services.Handlers;
using Xunit;

namespace SistemaAgendamento.Test
{
    public class TesteAplicacao
    {
        [Fact]
        static void TestInclusaoAgendamento() // Realizando Teste com o Memory DataBase
        {
            //arrange
            var salaTeste = new Sala(1, "1001");
            var comando = new CadastrarAgendamento("Titulo Teste", salaTeste, DateTime.Now, new DateTime(2019, 12, 31));

            var options = new DbContextOptionsBuilder<Infrastructure.DbContext>().UseInMemoryDatabase("DbTarefasContext").Options; // Utilizando Memory DataBase
            Infrastructure.DbContext contexto = new Infrastructure.DbContext(options);
            var repo = new RepositorioAgendamento(contexto);

            var handler = new CadastraAgendamentoHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            var tarefa = repo.ObtemAgendamentos(t => t.Titulo == "Titulo Teste");
            Assert.NotNull(tarefa); // Verifica se o valor pego não é nulo
        }

        [Fact]
        static void TestInclusaoAgendamentoExcecao() // Teste utilizando Moq, lançando uma exceção na Inclusão de Agendamentos
        {
            //arrange
            var salaTeste = new Sala(1, "1001");
            var comando = new CadastrarAgendamento("Titulo Teste", salaTeste, DateTime.Now, new DateTime(2019,12,31));

            var mock = new Mock<IRepositorioAgendamento>();
            mock.Setup(r => r.IncluirAgendamento(It.IsAny<AgendamentoModel>())).Throws(new Exception("Não foi possível incluir")); // Faz o lançamento da exceção
            var repo = mock.Object;

            var hardler = new CadastraAgendamentoHandler(repo);

            //act
            CommandResult resultado = hardler.Execute(comando);

            //assert
            Assert.False(resultado.IsSuccess); // Caso o resultado seja falso, significa que não conseguiu incluir agendamento por causa da exceção.
        }

        [Fact]
        static void TestVezesAtualizarAgendamentoChamado() // Verifica se o Atualiza Agendamento foi chamado
        {
            //arrange
            var comando = new GerenciaFimAgendamento();

            var mock = new Mock<IRepositorioAgendamento>();
            mock.Setup(r => r.AtualizarAgendamentos(It.IsAny<AgendamentoModel[]>()));
            var repo = mock.Object;

            var hardler = new GerenciaFimAgendamentoHandler(repo);

            //act
            hardler.Execute(comando);

            //assert
            mock.Verify(r => r.AtualizarAgendamentos(It.IsAny<AgendamentoModel>()), Times.AtLeastOnce());
            
        }
    }
}
